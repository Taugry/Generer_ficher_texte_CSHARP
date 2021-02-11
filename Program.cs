using System;
using System.IO;
using System.Text;
using System.Web;
using System.Diagnostics;

//fonction pour ne pas re-ecrire sur un ficher deja existant
//fonction recursive
static string testnom(string path, string ext)
{
    string filename;
    if (File.Exists(path))
    {
        //demande des supprimer ou non le ficher existant
        Console.WriteLine("Attention le ficher existe deja ! \nVoulez vous le supprimer Y/N ?");
        string res = Console.ReadLine();
        if (res == "Y" || res == "y")
            File.Delete(path);
        if (res == "N" || res == "n")
        {
            //rentre le nouveau nom du ficher
            Console.WriteLine("Veuillez rentrer un autre nom pour le ficher :");
            filename = Console.ReadLine();
            path = @"C:\Users\Portable\Desktop\" + filename + "." + ext;
            testnom(path, ext);
        }
    }
    return (path);
}


//programme principal
try
{
    //personalisation du nom du ficher
    Console.WriteLine("Veuillez entrer le nom du ficher: ");
    string filename = Console.ReadLine();
    Console.WriteLine("Veuillez entrer l'extention du ficher: ");
    string extention = Console.ReadLine();
    string path = @"C:\Users\Portable\Desktop\" + filename + "." + extention;

    // Vérifiez si le fichier existe déjà. Si oui, supprimez-le.    
    path = testnom(path, extention);

    // creation du ficher et Ajouter du texte au fichier  
    Console.WriteLine("Veuillez entrer le texte pour le sauvegarder dans le ficher txt : ");
    string text = Console.ReadLine();
    System.IO.File.WriteAllText(path, text);
    Process.Start("cmd", "/C " + "start notepad "+path);
}
catch (System.IO.IOException e)
{
    Console.WriteLine(e.Message);
}