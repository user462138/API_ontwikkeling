using Ninject;
using OplossingDiOefeningSamurai;

var kernel = new StandardKernel();
kernel.Bind<IWeapon>().To<Gun>();
kernel.Bind<ITrigger>().To<AutomaticTrigger>();
kernel.Bind<IWeapon>().To<Sword>();

var warrior = kernel.Get<Samurai>();
warrior.Attack("the evildoers");