
using System.Collections.Generic;
public abstract class Jogador
{
    public bool Vivo { get; set; } = true;
    public int Vidas { get; set; }
    public int Moedas { get; set; }
    public int Trofeus { get; set; } = 0;
    public List<T> maquinas { get; set; }

}
public class JogadorPadrao
{
     public JogadorPadrao(JogadorArgs args)
    {
        this.Vivo = args.Vivo;
        this.Vidas = args.Vidas;
        this.Moedas = args.Moedas;
        this.Trofeus = args.Trofeus;
        this.maquinas = args.maquinas;
    }

}
