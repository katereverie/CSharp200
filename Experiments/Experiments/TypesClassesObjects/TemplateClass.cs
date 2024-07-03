namespace TypesClassesObjects
{
    public class TemplateClass
    {
        public bool _iAmPublic;
        private bool _iAmPrivate;
        public static int _iAmPublicStatic;

        public TemplateClass()
        {
            _iAmPublic = true;
            _iAmPrivate = true;
            _iAmPublicStatic = 99;
        }
    }
}
