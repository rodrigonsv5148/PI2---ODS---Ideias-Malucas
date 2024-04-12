using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ideias 
{
    //informações da ficha------------------------------------------------------
    public string name;
    public int idade ;
    public string sexo;
    public string emprego;
    public string score;
    public string qteVisitas;
    public string conseguiuCredito;
    public string valorDoCredito;

    public int valorInvestimento;
    public string ideia;
    public int valorSustentabilidade;

    public string resposta;
}

[Serializable]
public class TodasIdeias 
{
    public Ideias[] listaIdeias;
}