using System.Linq;
using System.Collections.Generic;

public abstract class Batalha
{
    public var Jogador { get; set; }
    public var Inimigo { get; set; }
    public abstract int Luta() { }
    public abstract void GerarInimigos() { } //Atualizacao
    public abstract void RodaMetodosIniciais() { }
}

public class BatalhaPadrao
{
    public BatalhaPadrao(BatalhaArgs args)
    {
        this.Jogador = args.Jogador;
        this.Inimigo = args.Inimigo;
    }

    public override int Luta()
    {
        List<T> maquinasJogador = this.Jogador.Maquinas.Copy();
        List<T> maquinasInimigo = this.Inimigo.Maquinas.Copy();

        maquinasJogador.Reverse();
        maquinasInimigo.Reverse();

        while (maquinasInimigo.Count() > 0 && maquinasJogador.Count() > 0)
        {
            (maquinasJogador, maquinasInimigo) = maquinasInimigo[0].Atacar(maquinasJogador, maquinasInimigo);
            (maquinasInimigo, maquinasJogador) = maquinasJogador[0].Atacar(maquinasInimigo, maquinasJogador);
            
            if (maquinasInimigo[0].Vida <= 0)
            {
                maquinasInimigo.RemoveAt(0);
            }
            else if (maquinasJogador[0].Vida <= 0)
            {
                maquinasJogador.RemoveAt(0);
            }
        }

        if (maquinasJogador.Count() == maquinasInimigo.Count())
            return 0;
        else if (maquinasInimigo.Count() > 0)
            return -1;
        else if (maquinasJogador.Count() > 0)
            return 1;
    }
}