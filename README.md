# csharp-design-patterns
It is a udemy course to understand more about Design Patterns in C#

## Section: 0
Introduction

## Section: 1
The SOLID Design Principles
### - Single Responsability Principle (SRP):
Uma classe ou método não deve ter mais de uma responsabilidade.

### - Interfaace Segragation Principle: 
Uma interface não deve obrigar seus implementadores utilizarem métodos e propriedades que não são pertinentes para seus respectivos escopos.
	
### - Lisvok Substitution Principle: 
Classes que serão herdadas devem ser criados de uma maneira que seja possivel fazer uma reescrita de seus métodos e propriedades sem impactar o comportamento do objeto original caso exista.

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


## Section: 2
Builder

## Section: 3
Factories

## Section: 4
Prototype

## Section: 5
Singleton

## Section: 6
Adapter

## Section: 7
Bridge

## Section: 8
Composite
	### Observacoes
		Adicionando padrao composite

		pelo que eu entendi, acredito que sempre que tiver um objeto simples e uma 'lista' ou melhor dizendo, um objeto composto por muitos objetos de um mesmo tipo.

		para facilitar a manipulacao desses objetos e sincroniza-los entre si, uma solucao viavel pode ser o padrao 'composite'


## Section: 9
Decorator
	### Observacoes
		Adicionando padrao decorator

		pelo que eu entendi, acredito que sempre que houver necessidade de herança multipla e/ou eu quiser herdar comportamentos de outro objeto e adicionar mais features.

		um caminho interessante seria usar o padrão decorator

## Section: 10
Façade

## Section: 11
Flyweight

## Section: 12
Proxy

## Section: 13
Chain of Responsibility

## Section: 14
Command

## Section: 15
Interpreter

## Section: 16
Iterator

## Section: 17
Mediator
	### Observacoes
		Adicionando padrao mediator

		pelo que eu entendi, acredito que o padrão mediator serve para comunicação entre entidades que possuem relacionamento, porém não podem estar fortemente referenciadas umas nas outras.

		um caminho interessante seria usar o padrão mediator, assim cada "broker" ou "handler" tem por missão fazer a comunicação entre essas entidades ou objetos.

## Section: 18
Memento

## Section: 19
Null Object

## Section: 20
Observer

## Section: 21
State

## Section: 22
Strategy

## Section: 23
Template Method

## Section: 24
Visitor

## Section: 25
Course Summary

## Section: 26
Bonus Lectures
