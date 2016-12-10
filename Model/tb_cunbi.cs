using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    [Serializable]
    public partial class tb_cunbi
    {
        public tb_cunbi() { }

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
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// Amount
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// SettleDay
        /// </summary>		
        private int _settleday;
        public int SettleDay
        {
            get { return _settleday; }
            set { _settleday = value; }
        }
        /// <summary>
        /// SurplusDay
        /// </summary>		
        private int _surplusday;
        public int SurplusDay
        {
            get { return _surplusday; }
            set { _surplusday = value; }
        }
        /// <summary>
        /// States
        /// </summary>		
        private int _states;
        public int States
        {
            get { return _states; }
            set { _states = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// c001
        /// </summary>		
        private int _c001;
        public int c001
        {
            get { return _c001; }
            set { _c001 = value; }
        }
        /// <summary>
        /// c002
        /// </summary>		
        private decimal _c002;
        public decimal c002
        {
            get { return _c002; }
            set { _c002 = value; }
        }
        /// <summary>
        /// c003
        /// </summary>		
        private string _c003;
        public string c003
        {
            get { return _c003; }
            set { _c003 = value; }
        }
    }
}
