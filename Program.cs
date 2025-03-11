using System;
using System.Collections.Generic;

class PremiacionDeportiva {
    private Dictionary<string, HashSet<string>> disciplinas;

    public PremiacionDeportiva() {
        disciplinas = new Dictionary<string, HashSet<string>>();
    }

    public void RegistrarDisciplina(string nombreDisciplina) {
        if (!disciplinas.ContainsKey(nombreDisciplina)) {
            disciplinas[nombreDisciplina] = new HashSet<string>();
            Console.WriteLine($"✅ Disciplina '{nombreDisciplina}' registrada.");
        } else {
            Console.WriteLine($"⚠️ La disciplina '{nombreDisciplina}' ya existe.");
        }
    }

    public void AgregarPremiado(string nombreDisciplina, string nombreDeportista) {
        if (disciplinas.ContainsKey(nombreDisciplina)) {
            if (disciplinas[nombreDisciplina].Add(nombreDeportista)) {
                Console.WriteLine($"🏅 Deportista '{nombreDeportista}' premiado en '{nombreDisciplina}'.");
            } else {
                Console.WriteLine($"⚠️ '{nombreDeportista}' ya fue premiado en '{nombreDisciplina}'.");
            }
        } else {
            Console.WriteLine($"❌ La disciplina '{nombreDisciplina}' no existe. Regístrela primero.");
        }
    }

    public void MostrarPremiados() {
        Console.WriteLine("\n📋 Lista de disciplinas y deportistas premiados:");
        foreach (var disciplina in disciplinas) {
            Console.WriteLine($"🏆 {disciplina.Key}: {string.Join(", ", disciplina.Value)}");
        }
    }

    public void BuscarDeportista(string nombreDeportista) {
        Console.WriteLine($"\n🔍 Buscando a '{nombreDeportista}' en las disciplinas...");
        foreach (var disciplina in disciplinas) {
            if (disciplina.Value.Contains(nombreDeportista)) {
                Console.WriteLine($"✅ '{nombreDeportista}' fue premiado en '{disciplina.Key}'.");
                return;
            }
        }
        Console.WriteLine($"❌ '{nombreDeportista}' no tiene premios registrados.");
    }
}

class Program {
    static void Main() {
        PremiacionDeportiva premiacion = new PremiacionDeportiva();

        premiacion.RegistrarDisciplina("Atletismo");
        premiacion.RegistrarDisciplina("Natación");
        premiacion.RegistrarDisciplina("Fútbol");

        premiacion.AgregarPremiado("Atletismo", "Carlos Gómez");
        premiacion.AgregarPremiado("Natación", "Laura Pérez");
        premiacion.AgregarPremiado("Fútbol", "Luis Ramírez");
        premiacion.AgregarPremiado("Fútbol", "Ana Torres");

        premiacion.MostrarPremiados();

        premiacion.BuscarDeportista("Laura Pérez");
        premiacion.BuscarDeportista("Pedro Rodríguez");
    }
}
