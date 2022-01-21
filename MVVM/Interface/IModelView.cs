namespace CSFramework.MVVM.Interface
{
    public  interface IModelView
    {
        string ViewName { get;  set;}

        void InitBll();

        void InitBindData();

        void InitRegister();
    }
}
