static void IniciarAplicacao()
{
    CriarDiretorios();
    CriarArquivo();

    var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
    var destino = Path.Combine(Environment.CurrentDirectory, "globo", "America do Sul", "Argentina", "argentina.txt");

    MoverArquivo(origem, destino);

    CopiarArquivo(origem, destino);
}

static void CopiarArquivo(string pathOrigem, string PathDestino)
{
    if (File.Exists(PathDestino))
    {
        Console.WriteLine("Arquivo já existe no destino");
        return;
    }
    File.Copy(pathOrigem, PathDestino);
}

static void MoverArquivo(string pathOrigem, string PathDestino)
{

    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("O arquivo não exite na origem.");
        return;
    }
    if (File.Exists(PathDestino))
    {
        Console.WriteLine("O arquivo Já exite no destino.");
        return;
    }

    File.Move(pathOrigem, PathDestino);

}

static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
    if (!File.Exists(path))
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("População: 213MM");
        sw.WriteLine("IDH: 0,901");
        sw.WriteLine("Dados atualizados em: 2018");

    }


}

static void CriarDiretorios()
{

    var path = Path.Combine(Environment.CurrentDirectory, "globo");
    if (!Directory.Exists(path))
    {
        //Atribuindo a criação do diretório a uma variável, o método createsubdirectory ou o create directory envia as informações do caminho para variável
        var dirGlobo = Directory.CreateDirectory(path);

        var dirAmNorte = dirGlobo.CreateSubdirectory("America do Norte");
        var dirAmSul = dirGlobo.CreateSubdirectory("America do Sul");
        var dirAmCentral = dirGlobo.CreateSubdirectory("America Central");

        dirAmNorte.CreateSubdirectory("USA");
        dirAmNorte.CreateSubdirectory("Mexico");
        dirAmNorte.CreateSubdirectory("Canadá");

        dirAmCentral.CreateSubdirectory("Costa Rica");
        dirAmCentral.CreateSubdirectory("Panama");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Paraguai");
    }

}

static void LerDiretorios(string path)
{
    if (Directory.Exists(path))
    {
        var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories); //O * faz ele procurar por todas as pastas, e lista em uma array.

        foreach (var dir in diretorios)
        {
            var dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"[Nome]: {dirInfo.Name}");
            Console.WriteLine($"[Raiz]: {dirInfo.Root}");
            if (dirInfo.Parent != null)
                Console.WriteLine($"[Pai]: {dirInfo.Parent.Name}");
            Console.WriteLine("-------------------------------");
        }
    } else{
        Console.WriteLine($"caminho ({path})it Não existe.");
    }


}

var path = @"E:\Projetosdev\DirectoryAndDirectoryInfo\globo";
LerDiretorios(path);
Console.ReadLine();
