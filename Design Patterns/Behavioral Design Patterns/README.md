# [Behavioral Patterns](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Behavioral%20Design%20Patterns)

## [Chain of Responsibility](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Behavioral%20Design%20Patterns/13-Chain-of-Responsibility)
- Delega comandos a uma cadeia de objetos de processamento.

## [Command](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Behavioral%20Design%20Patterns/14-Command)
- Cria objetos que encapsulam ações e parâmetros.

## [Interpreter](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Behavioral%20Design%20Patterns/15-Interpreter)
- Implementa um idioma especializado.

## Iterator
- Acessa os elementos de um objeto seqüencialmente sem expor sua representação subjacente.

## [Mediator](https://github.com/matsennin/csharp-design-patterns/tree/master/Design%20Patterns/Behavioral%20Design%20Patterns/17-Mediator)
- Permite o baixo acoplamento entre classes, sendo a única classe que possui conhecimento detalhado de seus métodos.
- Pelo que eu entendi, acredito que o padrão mediator serve para comunicação entre entidades que possuem relacionamento, porém não podem estar fortemente referenciadas umas nas outras. Um caminho interessante seria usar o padrão mediator, assim cada "broker" ou "handler" tem por missão fazer a comunicação entre essas entidades ou objetos.

## Memento
- Fornece a capacidade de restaurar um objeto ao seu estado anterior.

## Null Object
- Na maioria das linguagens orientadas a objetos, como Java ou C #, as referências podem ser nulas. Essas referências precisam ser verificadas para garantir que elas não sejam nulas antes de chamar qualquer método, porque os métodos geralmente não podem ser chamados em referências nulas.

## Observer
- É um padrão de publicação / assinatura que permite que vários objetos observadores vejam um evento.

## State
- Permite que um objeto altere seu comportamento quando seu estado interno é alterado.

## Strategy
- Permite que uma família de algoritmos seja selecionada on-the-fly em tempo de execução.

## Template Method
- Define o esqueleto de um algoritmo como uma classe abstrata, permitindo que suas subclasses forneçam um comportamento concreto.

## Visitor
- Separa um algoritmo de uma estrutura de objeto, movendo a hierarquia de métodos em um objeto.
