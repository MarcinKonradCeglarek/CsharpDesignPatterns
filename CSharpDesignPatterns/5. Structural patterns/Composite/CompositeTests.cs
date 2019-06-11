namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using NUnit.Framework;

    [TestFixture]
    public class CompositeTests
    {
        private readonly IComposite leaf1 = new Leaf("L1");
        private readonly IComposite leaf2 = new Leaf("L2");
        private readonly IComposite leaf3 = new Leaf("L3");
        private readonly IComposite leaf4 = new Leaf("L4");

        [Test]
        public void Composite_2LeafsInside_ProperlyPrintsThem()
        {
            var composite = new Composite();
            composite.Add(this.leaf1);
            composite.Add(this.leaf2);

            Assert.AreEqual("[L1,L2]", composite.Print());
        }

        [Test]
        public void Composite_2SubComposites_ProperlyPrintsThem()
        {
            var parent = new Composite();

            var composite1 = new Composite();
            composite1.Add(this.leaf1);

            var composite2 = new Composite();
            composite2.Add(this.leaf2);

            parent.Add(composite1);
            parent.Add(composite2);

            Assert.AreEqual("[[L1],[L2]]", parent.Print());
        }

        [Test]
        public void Comsposite_TreeStructureWithOneBranchOnly_ProperlyPrintsThem()
        {
            var l4 = new Composite();
            l4.Add(this.leaf4);

            var l3 = new Composite();
            l3.Add(this.leaf3);
            l3.Add(l4);

            var l2 = new Composite();
            l2.Add(this.leaf2);
            l2.Add(l3);

            var root = new Composite();
            root.Add(this.leaf1);
            root.Add(l2);

            Assert.AreEqual("[L1,[L2,[L3,[L4]]]]", root.Print());
        }
    }
}