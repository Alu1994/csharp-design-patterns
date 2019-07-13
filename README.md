# Design Patterns in C#

## Introduction
- This repository has the mission to gather all the knowlegde of what i understood about SOLID and Design Patterns in C# from a Udemy Course, that was based on GOF and Uncle Bob Books.

# [The SOLID Design Principles](https://github.com/matsennin/csharp-design-patterns/blob/master/SOLID/SOLID_README.md)

# Design Patterns

<p align="center">
  <img src="https://github.com/matsennin/csharp-design-patterns/blob/master/GammaCategorizationGOF.png" />
</p>

## Section: 2
### Builder (Creational Pattern)
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

## Section: 3
### Factories (Creational Pattern)
- Uma Factory é um componente responsavel pela criação de um Objeto completo e não pedeço por pedaço.

## Section: 4
### Prototype (Creational Pattern)

## Section: 5
### Singleton (Creational Pattern)

## Section: 6
### Adapter (Structural Pattern)

## Section: 7
### Bridge (Structural Pattern)

## Section: 8
### Composite (Structural Pattern)
- Pelo que eu entendi, acredito que sempre que tiver um objeto simples e uma 'lista' ou melhor dizendo, um objeto composto por muitos objetos de um mesmo tipo. Para facilitar a manipulacao desses objetos e sincroniza-los entre si, uma solucao viavel pode ser o padrão 'composite'.


## Section: 9
### Decorator (Structural Pattern)
- Pelo que eu entendi, acredito que sempre que houver necessidade de herança multipla e/ou eu quiser herdar comportamentos de outro objeto e adicionar mais features. Um caminho interessante seria usar o padrão 'decorator'.

## Section: 10
### Façade (Structural Pattern)
- Pelo que eu entendi, acredito que uma Façade, seria uma camada de abstração de uma feature/negócio muito complexa, que não se faz necessária a sua exposição toda à todos os seus consumidores, mas sendo possível caso necessário a sua utilização em sua forma completa.
- O Façade define uma interface de nível superior que facilita o uso do subsistema.

## Section: 11
### Flyweight (Structural Pattern)
- Quando um dado/objeto é replicado e você somente precisa da "referencia" dele, uma maneira de tratar esse caso seria usando o Pattern Flyweight.
- O Flyweight seria uma camada a mais para responder por outra que pode sofrer latência.
- Um bom exemplo seria uma api de clientes, ela demora 10 segundos para responder e temos tem que consultar o mesmo cliente, sendo que o dado dele não muda. Então se utilizado o pattern flyweight nesse caso, para guardar a primeira chamada e responder às seguintes com o mesmo dado, você conseguiria resolveria esse problema de latência e somente buscaria dados na base principal, caso esse dado não estivesse em memória.

Ex:
```	
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns_11_Flyweight_2.Exercise
{
	public class Sentence
	{
		private string[] words;
		private Dictionary<int, WordToken> _tokens = new Dictionary<int, WordToken>();

		public Sentence(string plainText)
		{
			words = plainText.Split(' ');
		}

		public WordToken this[int index]
		{
			get
			{
				WordToken wt = new WordToken();
				_tokens.Add(index, wt);
				return _tokens[index];
			}
		}

		public override string ToString()
		{
			var ws = new List<string>();
			for (var i = 0; i < words.Length; i++)
			{
				var w = words[i];
				if (_tokens.ContainsKey(i) && _tokens[i].Capitalize)
					w = w.ToUpperInvariant();
				ws.Add(w);
			}
			return string.Join(" ", ws);
		}

		public class WordToken
		{
			public bool Capitalize;
		}
	}
}
```

## Section: 12
### Proxy (Structural Pattern)
- O Padrão Proxy serve para adicionar mais funcionalidades a uma interface existente.
- Por exemplo, você possui uma interface "ICarro" e você também possui uma classe "Carro" que implementa essa interface que possui o método "Dirigir". 
Caso você queira implementar uma funcionalidade de verificação de idade para dirigir esse carro, uma maneira interessante de resolver essa questão seria, criar uma classe
"CarroProxy" que teria a inteligencia de verificar a Idade do "Motorista" utilizando o próprio método "Dirigir" da interface, assim mantendo a implementação da mesma, 
porém adicionando mais uma funcionalidade, e depois da verificação chamar o método "Dirigir" da classe "Carro".

## Section: 13
### Chain of Responsibility (Behavioral Pattern)

## Section: 14
### Command (Behavioral Pattern)

## Section: 15
### Interpreter (Behavioral Pattern)

## Section: 16
### Iterator (Behavioral Pattern)

## Section: 17
### Mediator (Behavioral Pattern)
- Pelo que eu entendi, acredito que o padrão mediator serve para comunicação entre entidades que possuem relacionamento, porém não podem estar fortemente referenciadas umas nas outras. Um caminho interessante seria usar o padrão mediator, assim cada "broker" ou "handler" tem por missão fazer a comunicação entre essas entidades ou objetos.

## Section: 18
### Memento (Behavioral Pattern)

## Section: 19
### Null Object (Behavioral Pattern)

## Section: 20
### Observer (Behavioral Pattern)

## Section: 21
### State (Behavioral Pattern)

## Section: 22
### Strategy (Behavioral Pattern)

## Section: 23
### Template Method (Behavioral Pattern)

## Section: 24
### Visitor (Behavioral Pattern)

# Conclusion

## Section: 25
### Course Summary

# Bonus

## Section: 26
### Bonus Lectures

# Usefull Links
- [GOF Explanation](https://springframework.guru/gang-of-four-design-patterns/)
- [Null Object Pattern](https://en.wikipedia.org/wiki/Null_object_pattern/)
- [Udemy Course - Design Patterns in C# and .NET](https://www.udemy.com/design-patterns-csharp-dotnet/)

# Agradecimentos
- Thank you [Dmitri](https://github.com/nesteruk) for the exceptional course, it is being amazing learning all that good stuff!
- Obrigado [Carlão](https://github.com/ecezareti) pelos ensinamentos e pelas várias dicas de estudos que tive ao longo do tempo em que estivemos no mesmo time, e que até hoje segue me instruindo. Com você tive um incrivel exemplo de profissional e de mentor (mesmo me zuando muito kkk) que espero levar comigo por toda minha carreira, e que com o tempo eu consiga distribuir com outras pessoas, da mesma maneira que foi feito comigo.
- Obrigado [Hara](https://github.com/leandroharaoka) por estudar junto comigo e por tirar várias dúvidas comigo, acabei aprendendo mais ainda contigo, valeu man!
- Obrigado à todos os meus colegas de trabalho até o presente momento, sei que aprendi com todos, mesmo que tenha sido pelo menos um **if** rs.
