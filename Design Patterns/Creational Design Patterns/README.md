# Creational Patterns

## [Builder](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Creational%20Design%20Patterns/2-Builder)
- Usado para criar objetos complexos.
- É um padrão que auxilia na criação de um objeto, a partir de pedaços menores, fazendo a construção pedaço por pedaço.

Ex:
```
public class Carro
{
	public int Rodas;
	public int Portas;
	public int CapacidadeCombustivel;
}

public class CarroBuilder
{
	private Carro _carro;

	public CarroBuilder(Carro carro)
	{
		_carro = carro;
	}

	public CarroBuilder AddRodas(int rodas)
	{
		_carro.Rodas += rodas;
		return this;
	}

	public CarroBuilder AddPortas(int portas)
	{
		_carro.Portas += portas;
		return this;
	}

	public CarroBuilder AddCapacidadeCombustivel(int capacidadeCombustivel)
	{
		_carro.CapacidadeCombustivel += capacidadeCombustivel;
		return this;
	}
}

public class Program
{
	static void Main(string[] args)
	{
		var carro = new Carro();
		var carroBuilder = new CarroBuilder(carro);

		carroBuilder
			.AddRodas(1)
			.AddRodas(3)
			.AddPortas(2)
			.AddPortas(2)
			.AddCapacidadeCombustivel(200);

		Console.WriteLine(carro.Rodas);
		Console.WriteLine(carro.Portas);
		Console.WriteLine(carro.CapacidadeCombustivel);
	}
}
```

## Factory
- Abstract Factory: Permite a criação de objetos sem especificar seu tipo concreto.
- Factory Method: Cria objetos sem especificar a classe exata a ser criada.
- Uma Factory é um componente responsavel pela criação de um Objeto completo e não pedeço por pedaço.

## Prototype
- Cria um novo objeto de um objeto existente.

## Singleton
- Garante que apenas uma instância de um objeto seja criada.
