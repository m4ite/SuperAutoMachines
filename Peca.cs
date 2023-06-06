using System.Collections.Generic;
public abstract class Peca
{
    private int Xp { get; set; }
    private int Tier { get; set; }
    private int Vida { get; set; } 
    private int Valor { get; set; }
    private int Nivel { get; set; }
    private int Ataque { get; set; }
    private string Nome { get; set; }
    public virtual void BuffInicial(MercadoArgs args) { }
    public virtual void BuffFinal(MercadoArgs args) { }

    public virtual (List<T>, List<T>) Atacar(List<T> voce, List<T> inimigo) 
    {
        Peca.TomarDano(voce, inimigo);
        return (voce, inimigo);
    }
    public virtual (List<T>, List<T>) TomarDano(List<T> voce, List<T> inimigo) 
    {
        inimigo[0].Vida -= voce[0].Dano;
        return (voce, inimigo);
    }
    public virtual int PedirValor() 
    {
        return this.Valor;
    }
}

// ----- TIER 1 -----
public class Martelo : Peca
{
    public Martelo()
    {
        this.Xp = 1;
        this.Tier = 1;
        this.Ataque = 2;
        this.Vida = 3;
        this.Nome = "Martelo";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class ChaveDeFenda : Peca
{
    public ChaveDeFenda()
    {
        this.Xp = 1;
        this.Tier = 1;
        this.Ataque = 2;
        this.Vida = 3;
        this.Nome = "Chave de Fenda";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class Esterira : Peca 
{
    public Esterira()
    {
        this.Xp = 1;
        this.Tier = 1;
        this.Ataque = 3;
        this.Vida = 1;
        this.Nome = "Esteira";
        this.Nivel = 1;
        this.Valor = 3;
        this.Jogo = args.Jogo;
    }

    public override int PedirValor()
    {
        return this.Valor + 1;
    }
}

// ----- TIER 2 -----
public class FuradeiradeColuna : Peca
{
    public FuradeiradeColuna()
    {
        this.Xp = 1;
        this.Tier = 2;
        this.Ataque = 3;
        this.Vida = 5;
        this.Nome = "Furadeira de Coluna";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class FornoIndustrial : Peca
{
    public FornoIndustrial()
    {
        this.Xp = 1;
        this.Tier = 2;
        this.Ataque = 1;
        this.Vida = 3;
        this.Nome = "Forno Industrial";
        this.Nivel = 1;
        this.Valor = 3;
    }

    public override BuffInicial()
    {
        Jogador.Moedas += 1;
    }
}
public class RetificaPlana : Peca
{
    public RetificaPlana()
    {
        this.Xp = 1;
        this.Tier = 2;
        this.Ataque = 4;
        this.Vida = 2;
        this.Nome = "Retifica Plana";
        this.Nivel = 1;
        this.Valor = 3;
    }
}

// ----- TIER 3 -----
public class FuradeiradeCoordenada : Peca
{
    public FuradeiradeCoordenada()
    {
        this.Xp = 1;
        this.Tier = 3;
        this.Ataque = 3;
        this.Vida = 5;
        this.Nome = "Furadeira de Coordenada";
        this.Nivel = 1;
        this.Valor = 3;
    }

    public override void TomarDano(List<T> voce, List<T> inimigo)
    {
        inimigo[0].Vida -= voce[0].Dano;

        if (voce[0].Vida >= 1)
        {
            Random rand = new Random.Next(1, inimigo.Count());
            inimigo[rand].Vida -= voce[0].Ataque;
        }

        
        return (voce, inimigo);
    }
}
public class FornoIndustrialEletrico : Peca
{
    public FornoIndustrialEletrico()
    {
        this.Xp = 1;
        this.Tier = 3;
        this.Ataque = 4;
        this.Vida = 3;
        this.Nome = "Forno Industrial Eletrico";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class RetificaCilindrica : Peca
{
    public RetificaCilindrica()
    {
        this.Xp = 1;
        this.Tier = 3;
        this.Ataque = 2;
        this.Vida = 6;
        this.Nome = "Retifica Cilindrica";
        this.Nivel = 1;
        this.Valor = 3;
    }
}

// ----- TIER 4 -----
public class Fresa : Peca
{
    public Fresa()
    {
        this.Xp = 1;
        this.Tier = 4;
        this.Ataque = 4;
        this.Vida = 5;
        this.Nome = "Fresa";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class Torno : Peca
{
    public Torno()
    {
        this.Xp = 1;
        this.Tier = 4;
        this.Ataque = 5;
        this.Vida = 3;
        this.Nome = "Torno";
        this.Nivel = 1;
        this.Valor = 3;
    }

    public override BuffFinal(MercadoArgs args)
    {
        bool possuiNivel3 = false;
        var pecas = args.PecasDoJogo;
        foreach (var peca in pecas)
        {
            if(peca.Nivel == 3)
            {
                possuiNivel3 = true;
            }
        }

        if(possuiNivel3)
        {
            this.Ataque +=2;
            this.Vida +=2;
        }
    }
}

// ----- TIER 5 -----
public class TornoCNC : Peca
{
    public TornoCNC()
    {
        this.Xp = 1;
        this.Tier = 5;
        this.Ataque = 5;
        this.Vida = 8;
        this.Nome = "Torno CNC";
        this.Nivel = 1;
        this.Valor = 3;
    }
}
public class FresaCNC : Peca
{
    public FresaCNC()
    {
        this.Xp = 1;
        this.Tier = 5;
        this.Ataque = 8;
        this.Vida = 4;
        this.Nome = "Fresa CNC";
        this.Nivel = 1;
        this.Valor = 3;
    }
}

// ----- TIER 6 -----
public class CorteaPlasmaCNC : Peca
{
    public CorteaPlasmaCNC()
    {
        this.Xp = 1;
        this.Tier = 6;
        this.Ataque = 6;
        this.Vida = 8;
        this.Nome = "Corte a Plasma CNC";
        this.Nivel = 1;
        this.Valor = 3;
    }
}