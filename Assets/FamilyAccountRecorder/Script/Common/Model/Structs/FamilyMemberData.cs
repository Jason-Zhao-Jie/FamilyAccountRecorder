namespace FamilyAccountRecorder.Common.Model.Structs
{
    /// <summary>
    /// ��ʾ�û�Ȩ�޵�ö��
    /// </summary>
    public enum AthorityType : int
    {
        /// <summary> ������ </summary>
        Owner,
        /// <summary> ����Ա </summary>
        Administrator,
        /// <summary> ��ͨ�û� </summary>
        User,
        /// <summary> ֻ���ÿ� </summary>
        Guest,
        /// <summary> ���׶������� </summary>
        BillTarget,
    }

    /// <summary>
    /// ��ʾ�û��Ա��ö��
    /// </summary>
    public enum Gender : int
    {
        /// <summary> δ֪�Ա� </summary>
        Unknown,
        /// <summary> ���� </summary>
        Male,
        /// <summary> Ů�� </summary>
        Female,
        /// <summary> ������֯ </summary>
        Group,
        /// <summary> �����Ա� </summary>
        Others,
    }

    /// <summary>
    /// ��ʾ�û��Ļ�������
    /// </summary>
    [System.Serializable]
    public struct FamilyMemberData
    {
        public string uid;
        /// <summary> �û�Ȩ�� </summary>
        public AthorityType athority;
        /// <summary> �û��������ɸ��� </summary>
        public string name;
        /// <summary> �û��Ա𣬿ɸ��� </summary>
        public Gender gender;
        /// <summary> �û�ǩ�����ɸ��� </summary>
        public string signWords;
        /// <summary> �û��ʽ��˻� <seealso cref="PocketAccountData.uid"/> </summary>
        public string[] accounts;
    }

}