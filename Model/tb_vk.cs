using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    [Serializable]
    public partial class tb_vk
    {
        public tb_vk() { }

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// vkname
        /// </summary>		
        private string _vkname;
        public string vkname
        {
            get { return _vkname; }
            set { _vkname = value; }
        }
        /// <summary>
        /// imgurl
        /// </summary>		
        private string _imgurl;
        public string imgurl
        {
            get { return _imgurl; }
            set { _imgurl = value; }
        }
        /// <summary>
        /// walletaddress
        /// </summary>		
        private string _walletaddress;
        public string walletaddress
        {
            get { return _walletaddress; }
            set { _walletaddress = value; }
        }
        /// <summary>
        /// v001
        /// </summary>		
        private int _v001;
        public int v001
        {
            get { return _v001; }
            set { _v001 = value; }
        }
        /// <summary>
        /// v002
        /// </summary>		
        private decimal _v002;
        public decimal v002
        {
            get { return _v002; }
            set { _v002 = value; }
        } 
    }
}
