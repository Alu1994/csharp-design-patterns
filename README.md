# csharp-design-patterns
It is a udemy course to understand more about Design Patterns in C#

## Section: 0
## Introduction

## Section: 1
### The SOLID Design Principles
### - Single Responsability Principle (SRP):
Uma classe ou método não deve ter mais de uma responsabilidade.

### - Liskov Substitution Principle: 
Classes que serão herdadas devem ser criadas de uma maneira que seja possível fazer uma reescrita de seus métodos e propriedades sem impactar o comportamento do objeto PAI.

Liskov Ex: 
```
public class Parent
{
	public virtual void X()
	{
		x = y + y;
	}
}

public class Child : Parent
{	
	public override void X()
	{
		x = (y + y) * 2;
	}
}
```

### - Interface Segregation Principle: 
As interfaces que especificam as funcionalidades de seus implementadores devem ser criadas de forma granular, 
para não obrigar os implementadores a criarem especificações de funções que não façam parte de seu escopo.

## Section: 2
### Builder

## Section: 3
### Factories

## Section: 4
### Prototype

## Section: 5
### Singleton

## Section: 6
### Adapter

## Section: 7
### Bridge

## Section: 8
### Composite
- Pelo que eu entendi, acredito que sempre que tiver um objeto simples e uma 'lista' ou melhor dizendo, um objeto composto por muitos objetos de um mesmo tipo. Para facilitar a manipulacao desses objetos e sincroniza-los entre si, uma solucao viavel pode ser o padrão 'composite'.


## Section: 9
### Decorator
- Pelo que eu entendi, acredito que sempre que houver necessidade de herança multipla e/ou eu quiser herdar comportamentos de outro objeto e adicionar mais features. Um caminho interessante seria usar o padrão 'decorator'.

## Section: 10
### Façade
- Pelo que eu entendi, acredito que uma Façade, seria uma camada de abstração de uma feature/negócio muito complexa, que não se
faz necessária a sua exposição toda à todos os seus consumidores, mas sendo possível caso necessário a sua utilização em sua forma completa.
- O Façade define uma interface de nível superior que facilita o uso do subsistema.

## Section: 11
### Flyweight

## Section: 12
### Proxy

## Section: 13
### Chain of Responsibility

## Section: 14
### Command

## Section: 15
### Interpreter

## Section: 16
### Iterator

## Section: 17
### Mediator
- Pelo que eu entendi, acredito que o padrão mediator serve para comunicação entre entidades que possuem relacionamento, porém não podem estar fortemente referenciadas umas nas outras. Um caminho interessante seria usar o padrão mediator, assim cada "broker" ou "handler" tem por missão fazer a comunicação entre essas entidades ou objetos.

## Section: 18
### Memento

## Section: 19
### Null Object

## Section: 20
### Observer

## Section: 21
### State

## Section: 22
### Strategy

## Section: 23
### Template Method

## Section: 24
### Visitor

## Section: 25
### Course Summary

## Section: 26
### Bonus Lectures
