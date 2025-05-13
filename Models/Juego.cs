using System.ComponentModel;

class Juego{
    public static string palabra; 
    public static string getPalabra(){
        return palabra;
    }   
    public static char[] palabraParcial;  
    public static string getPalabraParcial() {
        return string.Join(" ", palabraParcial);
    }  
    public static List<char>usadas;
    public static List<char> getLetrasUsadas(){
        return usadas;
    }    
    public static int intentos;  
    public static int getIntentos(){
        return intentos;
    }
    public static bool termino; 
    public static bool Termino(){
        return termino;
    }   
    public static bool gano;    
    public static bool Gano(){
        return gano;
    }   
    public static void inicializarJuego(){
        palabra=generarPalabra();    
        palabraParcial=new string('_', palabra.Length).ToCharArray();;
        usadas=new List<char>();
        intentos=0;
        termino=false;
        gano=false;
    }    
    public static void ArriesgarLetra(char Larriesgada){
        Larriesgada = char.ToUpper(Larriesgada);               
        if (!usadas.Contains(Larriesgada) && termino==false){
            usadas.Add(Larriesgada);
            bool adivino=false;
            for (int i = 0; i < palabra.Length; i++){
                if (palabra[i] == Larriesgada){
                    palabraParcial[i] = Larriesgada;
                    adivino = true;
                }
            }
            if (!palabraParcial.Contains('_')){
                termino = true;
                gano = true;
            }
            if (!adivino){
                intentos++;
            }
            if (intentos >= 5){
                termino = true;
            }
        } 
    }
    public static void ArriesgarPalabra(string Parriesgada){
        string palabraArriesgada = Parriesgada.ToUpper();
        if (termino==false){                       
            if (palabraArriesgada == palabra){
                palabraParcial = palabra.ToCharArray();
                termino = true;
                gano = true;
            }
            else{
                termino=true;
            }
        }
    }
    public static string generarPalabra(){
        Random palabraRandom=new Random();
        List<string> palabras = new List<string>() {"SOL", "LUNA", "AGUA", "FUEGO", "TIERRA", "AIRE", "VIDA", "AMOR", "TIEMPO", "DORMIR",
            "CAMINO", "BOSQUE", "MAR", "ESTRELLA", "ALEGRIA", "ESPERANZA", "FORTALEZA", "LIBERTAD", "SILENCIO", "LUZ",
            "PAZ", "ILUSION", "CIELO", "NUBE", "LLUVIA", "VIENTO", "ARENA", "COLINA", "VALLE", "RIO",
            "FLOR", "ARBOL", "FRUTO", "RAIZ", "TRUENO", "RELAMPAGO", "NIEVE", "HIELO", "FLORES", "HOJAS",
            "SOMBRA", "FANTASIA", "REALIDAD", "CORAZON", "ALMA", "MENTE", "CUERPO", "ESPIRITU", "ENERGIA", "DESTINO",
            "SENDEROS", "HORIZONTE", "OCASO", "AMANECER", "ATARDECER", "NOCHE", "DIA", "INVIERNO", "VERANO", "ESTACION",
            "PRIMAVERA", "FELICIDAD", "TRISTEZA", "VALENTIA", "MIEDO", "ENCUENTRO", "DESPEDIDA", "RECUERDO", "SENTIR", "ANHELAR",
            "CRECER", "APRENDER", "CAMBIAR", "RENACER", "IMAGINAR", "CREAR", "VOLAR", "CAER", "LEVANTAR", "ANDAR",
            "DESCANSAR", "ABRAZO", "MIRADA", "VOZ", "PALABRA", "GRITO", "SUSPIRO", "CANTO", "MUSICA", "POESIA",
            "HISTORIA", "LEYENDA", "CAMPO", "CIUDAD", "CAMINAR", "CORRER", "NADAR", "VIVIR", "EXISTIR", "LUMINOSIDAD"}; 
        palabra = palabras[palabraRandom.Next(palabras.Count)];
        return palabra;
    }
}