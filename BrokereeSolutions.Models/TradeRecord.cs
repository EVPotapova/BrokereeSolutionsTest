using System.Runtime.InteropServices;

namespace BrokereeSolutions.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TradeRecord
    {
        public int id;
        public int account;
        public double volume;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string comment;

        public string ToCsvString()
        {
            return string.Format("{0};{1};{2};{3}\n", id, account, volume, comment);
        }
    }
}
