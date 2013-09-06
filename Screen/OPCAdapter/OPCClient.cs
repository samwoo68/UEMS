using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Collections;
using System.IO;
using CommLib;


using System.Threading;

namespace OPCAdapter
{
    public partial class OPCClient : System.ComponentModel.Component, ICommComponent
    {
        OPCAutomation.OPCItems OPCItemCollection;
        OPCAutomation.OPCServer ConnectedOPCServer;
        OPCAutomation.OPCGroups ConnectedServerGroup;
        OPCAutomation.OPCGroup ConnectedGroup;

        Dictionary<string, OPCVariable> variableDic = new Dictionary<string, OPCVariable>();
        Dictionary<int, RegisterVariable> registerDic = new Dictionary<int, RegisterVariable>();

        string server = "";
        string group = "Group";
        string topic = "";
        Control synchronizingObject = null;
        short ID = 0;

        public OPCClient()
        {
            InitializeComponent();
        }

        #region Property
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public Control SynchronizingObject
        {
            get
            {
                IDesignerHost host = null;
                object obj = null;

                if (synchronizingObject == null && this.DesignMode)
                {
                    host = (IDesignerHost)this.Site.GetService(typeof(IDesignerHost));

                    if (host != null)
                    {
                        obj = host.RootComponent;
                        synchronizingObject = (Control)obj;
                    }
                }

                return synchronizingObject;
            }
            set
            {
                if (value != null)
                {
                    synchronizingObject = value;
                }
            }
        }

        public bool ItemUpdate
        {
            get
            {
                return timer_update.Enabled;
            }
            set
            {
                timer_update.Enabled = value;                
            }
        }
        #endregion

        #region Interface
        
        public void Connect()
        {
            string DirPath = "C:\\OPCLOG";
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            string filePath = DirPath+"\\OPClog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"; 
            StreamWriter Writer = new StreamWriter(filePath, true);
            Writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "     --Start OPC --");            
            Writer.Close();
           
           
            
            try
            {
                ConnectedOPCServer = new OPCAutomation.OPCServer();
                ConnectedOPCServer.Connect("Intellution.LSEOPC");

                ConnectedServerGroup = ConnectedOPCServer.OPCGroups;
                ConnectedGroup = ConnectedServerGroup.Add(group);
                ConnectedGroup.UpdateRate = 500;
                OPCItemCollection = ConnectedGroup.OPCItems;
              
                Writer = new StreamWriter(filePath, true);
                Writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "     --Connected OPC Succ --");
                Writer.Close();
               
                
            }
            catch
            {
                
                Writer = new StreamWriter(filePath, true);                   
                Writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "     --Connected OPC Fail--");
                Writer.Close();
              
                
            }
        }

        public void Disconnect()
        {
            ConnectedOPCServer.Disconnect();
        }

        public int Subscribe(string variable, UpdateMode mode, int updateTime, ReturnValues CallBack)
        {
            if (ConnectedOPCServer == null || ConnectedOPCServer.ServerState == 0 || variable.Length == 0)
                return -1;
            
            RegisterVariable varInfo = new RegisterVariable();

            varInfo.Name = variable;
            varInfo.Mode = mode;
            varInfo.UpdateTime = updateTime;
            varInfo.CallBack = new List<ReturnValues>();
            
            foreach (int id in registerDic.Keys)
            {
                if (registerDic[id].Name == variable)
                {
                    registerDic[id].CallBack.Add(CallBack);
                    return id;
                }
            }

            if (!variableDic.ContainsKey(variable))
            {
                OPCVariable info = new OPCVariable();

                info.ID = ++ID;

                variableDic.Add(variable, info);
            }
            
            if (mode != UpdateMode.NoUpdate)
            {
                try
                {
                    OPCItemCollection.AddItem(variable, ID);

                    varInfo.CallBack.Add(CallBack);

                    registerDic.Add(variableDic[variable].ID, varInfo);
                }
                catch
                {
                }
            }

            return ID;
        }
        
        public void Unsubscribe(int id)
        {
            if (registerDic.ContainsKey(id))
            {
                if (variableDic.ContainsKey(registerDic[id].Name))
                {
                    variableDic.Remove(registerDic[id].Name);
                }

                registerDic.Remove(id);
            }
        }

        public string ReadAny(string variable)
        {
            if (!variableDic.ContainsKey(variable))
            {
                Subscribe(variable, UpdateMode.Cyclic, 500, null);
            }

            object data = "";
        
            try
            {
                object Value;
                object Quality;
                object TMS;

                OPCItemCollection.Item(variableDic[variable].ID).Read(variableDic[variable].ID, out Value, out Quality, out TMS);

                data = OPCItemCollection.Item(variableDic[variable].ID).Value.ToString();
                variableDic[variable].data = data.ToString();

                if (variable == "PLC-XGK:D00514" || variable == "PLC-XGK:D00625")
                    IronControls.API.OutputDebugString(variable + " Read Success, Value = " + data.ToString());
            }
            catch (Exception ex)
            {
                string DirPath = "C:\\OPCLOG";
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                string filePath = DirPath + "\\OPClog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
               
                StreamWriter Writer = new StreamWriter(filePath, true);
                Writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "     " + variable + " Read Fail ->" + ex.ToString());
                Writer.Close();

                IronControls.API.OutputDebugString(variable + " Read Fail");

                data = variableDic[variable].data;
                
            }

            return data.ToString();
        }

        public object ReadAny(string variable, Type type)
        {
            //if (!variableDic.ContainsKey(variable))
            //{
            //    OPCVariable info = new OPCVariable();

            //    info.ID = ++ID;

            //    variableDic.Add(variable, info);
            //}

            //object data = "";

            //try
            //{
            //    object Value;
            //    object Quality;
            //    object TMS;

            //    OPCItemCollection.Item(variableDic[variable].ID).Read(variableDic[variable].ID, out Value, out Quality, out TMS);

            //    data = OPCItemCollection.Item(variableDic[variable].ID).Value.ToString();
            //}
            //catch
            //{
            //}

            //return data;
            return null;
            
        }

        public object ReadBuffer(string device, int type, int addr, int size)
        {
            return null;
        }

        public int WriteData(string variable, object data)
        {
            if (!variableDic.ContainsKey(variable))
            {
                Subscribe(variable, UpdateMode.Cyclic, 500, null);
            }

            try
            {
                OPCItemCollection.Item(variableDic[variable].ID).Write(data);
                return 1;               
            }
            catch (Exception ex)            
            {
                string DirPath = "C:\\OPCLOG";
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                string filePath = DirPath + "\\OPClog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";               
                StreamWriter Writer = new StreamWriter(filePath, true);
                Writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "     " + variable + " write Fail ->" + ex.ToString());
                Writer.Close();
               
               // data = variableDic[variable].data;             

            }
            return 0;
        }

        public int WriteBuffer(string device, int type, int addr, int size, object data)
        {
            return 0;
        }
        #endregion

        private void timer_update_Tick(object sender, EventArgs e)
        {
            foreach (string tag in variableDic.Keys)
            {
                object value = ReadAny(tag);

                object[] param = new object[2];
                object[] data = new object[2];

                data[0] = value;
                data[1] = DateTime.Now;

                param[0] = variableDic[tag].ID;
                param[1] = data;

                try
                {
                    foreach (CommLib.ReturnValues CallBack in registerDic[variableDic[tag].ID].CallBack)
                    {
                        synchronizingObject.BeginInvoke(CallBack, param);
                    }
                }
                catch
                {
                }
            }
        }
    }
}
