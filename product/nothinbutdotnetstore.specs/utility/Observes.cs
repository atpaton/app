namespace nothinbutdotnetstore.specs.utility
{
    public class Observes<Contract, Implementation> :
        Machine.Specifications.DevelopWithPassion.Rhino.Observes<Contract, Implementation>
        where Implementation : Contract
    {
        public static Dependency the_sut_constructor_needs_a<Dependency>() where Dependency : class
        {
            return the_dependency<Dependency>();
        }
    }
}