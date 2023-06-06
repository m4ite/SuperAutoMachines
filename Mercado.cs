using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Mercado
{
    public Random Rand { get; set; }
    public Peca PecaAtual { get; set; } 
    public Jogador Jogador { get; set; }
    public List<Peca> PecasDoJogo { get; set;}
    public List<Peca> PecasDisponiveis { get; set;}
    public int LimiteMaquinasMercado { get; set; }
    public abstract void Vender() { }
    public abstract void Comprar() { }
    public abstract void Atualizar() { }
    public abstract void JuntarPeca() { }
    public abstract void Sair() { }
}

public class MercadoPadrao : Mercado 
{
    public MercadoPadrao(MercadoArgs args)
    {
        this.PecaAtual = null;
        this.Jogador = args.Jogador;
        this.PecasDoJogo = args.PecasDoJogo;
        this.PecasDisponiveis = args.PecasDisponiveis;
        this.LimiteMaquinasMercado = args.LimiteMaquinasMercado;
    }

    public override void Comprar(int indexPecaMercado, int posicaoFinal)
    {
        if(this.PecaAtual)
        {
            if (Jogador.Maquinas[posicaoFinal] == null)
                if(Jogador.Moedas >= this.PecaAtual.Valor)
                {
                    Jogador.Moedas -= this.PecaAtual.Valor;
                    this.PecaAtual.Valor = this.PecaAtual.Nivel;
                    Jogador.Maquinas[posicaoFinal] = this.PecaAtual;
                    PecasDisponiveis[indexPeca] = null;
                }
            else if (this.PecaAtual.Nome == Jogador.Maquinas[posicaoFinal].Nome)
            {
                if(Jogador.Moedas >= this.PecaAtual.Valor)
                {
                    Jogador.Moedas -= this.PecaAtual.Valor;
                    this.PecaAtual.Valor = this.PecaAtual.Nivel;
                    PecasDisponiveis[indexPeca] = null;
                    Jogador.Maquinas[posicaoFinal] = JuntarPeca(this.PecaAtual, this.Jogador.Maquinas[posicaoFinal]);
                }
            }
        }
    }
    public override void Vender(int indexPeca)
    {
        if(this.Jogador.Maquinas[indexPeca] != null)
        {
            this.Jogador.Moedas += this.Jogador.Maquinas[indexPeca].PedirValor();
            this.Jogador.Maquinas[indexPeca] = null;
        }
    }
    public override void Atualizar()
    {
        if(this.Jogador.Moedas >= 1)
        {
            this.Jogador.Moedas -= 1;
            for (int i = 0; i < this.LimiteMaquinasMercado; i++)
            {
                this.PecasDisponiveis[i] = this.PecasDoJogo[this.Rand.Next(1, this.PecasDoJogo.Count())];
            }
        }
    }
    public override var JuntarPeca(var peca1, var peca2)
    {
        if (peca1.Nivel != 3 && peca2.Nivel != 3)
        {
            int novoXp = peca1.Xp + peca2.Xp;
            int novaVida = peca1.Vida > peca2.Vida ? peca1.Vida + 1 : peca2.Vida + 1;
            int novoAtaque = peca1.Ataque > peca2.Ataque ? peca1.Ataque + 1 : peca2.Ataque + 1;

            int novoNivel = ( novoXp / 3 ) + 1 > 3 ? 3 : ( novoXp / 3 ) + 1;

            peca1.Xp = novoXp;
            peca1.Vida = novaVida;
            peca1.Ataque = novoAtaque;
            peca1.Nivel = novoNivel;

            return peca1;
        }
    }
    public override void Sair()
    {
        for(int i = 0; i < PecasDisponiveis.Count(); i++)
        {
            PecasDisponiveis[i].Buff(MercadoArgs);
        }
    }
  
}

public class MercadoInimigo : MercadoPadrao
{
    
}