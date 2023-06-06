public class ProcessArgs
{
    private static ProcessArgs empty = new ProcessArgs();
    public static ProcessArgs Empty => empty;
}

public class PecaArgs : ProcessArgs
{
    private int Xp { get; set; }
    private int Tier { get; set; }
    private int Vida { get; set; } 
    private int Valor { get; set; }
    private int Nivel { get; set; }
    private int Ataque { get; set; }
    private string Nome { get; set; }
}

public class JogadorArgs : ProcessArgs
{
    public bool Vivo { get; set; }
    public int Vidas { get; set; }
    public int Moedas { get; set; }
    public int Trofeus { get; set; }
    private List<T> maquinas { get; set; }
}

public class BatalhaArgs : ProcessArgs
{
    public var Jogador { get; set; }
    public var Inimigo { get; set; }
}

public class MercadoArgs : ProcessArgs
{
    public Random Rand { get; set; }
    public var PecaAtual { get; set; } 
    public Jogador Jogador { get; set; }
    public List<T> PecasDoJogo { get; set;}
    public List<T> PecasDisponiveis { get; set;}
    public int LimiteMaquinasMercado { get; set; }
}
