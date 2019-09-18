namespace CSharpDesignPatterns._4._Creational_patterns.FactoryMethod
{
    using System;

    using CSharpDesignPatterns._4._Creational_patterns.FactoryMethod.Model;

    /*
     * https://refactoring.guru/design-patterns/factory-method
     */
    public static class DriverFactoryMethod
    {
        public static IDriver GetDriver(DriverType type)
        {
            switch (type)
            {
                case DriverType.Graphics:
                    return new GraphicsCardDriver();
                case DriverType.HardDisk:
                    return new HardDiskDriver();
                case DriverType.Usb:
                    return new UsbDriver();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}