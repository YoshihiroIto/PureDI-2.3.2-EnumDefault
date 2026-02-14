using Pure.DI;
using Repro.Domain;

DI.Setup(nameof(Composition))
    .Bind<IDependency1>().To<Dependency1>()
    .Bind<IDependency2>().To<Dependency2>()
    .Bind<IDependency3>().To<Dependency3>()
    .Bind<IDependency4>().To<Dependency4>()
    .Bind<IDependency5>().To<Dependency5>()
    .Bind<IDependency6>().To<Dependency6>()
    .Bind<IDependency7>().To<Dependency7>()
    .Bind<IService>().To<Service>()
    .Root<IService>("Root");

var composition = new Composition();
_ = composition.Root;

interface IDependency1;
interface IDependency2;
interface IDependency3;
interface IDependency4;
interface IDependency5;
interface IDependency6;
interface IDependency7;

sealed class Dependency1 : IDependency1;
sealed class Dependency2 : IDependency2;
sealed class Dependency3 : IDependency3;
sealed class Dependency4 : IDependency4;
sealed class Dependency5 : IDependency5;
sealed class Dependency6 : IDependency6;
sealed class Dependency7 : IDependency7;

interface IService
{
    FileItemFormats CurrentMode { get; }
}

abstract class BaseService(FileItemFormats mode)
{
    public FileItemFormats CurrentMode { get; } = mode;
}

partial class Service(
    IDependency1 dependency1,
    IDependency2 dependency2,
    IDependency3 dependency3,
    IDependency4 dependency4,
    IDependency5 dependency5,
    IDependency6 dependency6,
    IDependency7 dependency7,
    FileItemFormats mode = FileItemFormats.Archive)
    : BaseService(mode), IService
{
    private readonly object _ = new
    {
        dependency1,
        dependency2,
        dependency3,
        dependency4,
        dependency5,
        dependency6,
        dependency7
    };
}

partial class Composition;
