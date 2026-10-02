using System;

namespace TransformadaLaplace
{
	class Program
	{
		static void Main(string[] args)
		{
			// INICIO

			// Definir variables

			string L = "e^(-st)";
			string L2 = "-(1/s)e^(-st)";
			string funcion = "";
			string resultadoF_s = "";
			int opcion = 0;
			string valorConstante = "a";

			Console.WriteLine("           TRANSFORMADA DE LAPLACE              ");

			// // Resolver varios casos
			// Escribir Ingrese función f(t)

			Console.WriteLine("Seleccione la función f(t) que desea transformar:");
			Console.WriteLine("1.  f(t) = 1");
			Console.WriteLine("2.  f(t) = t");
			Console.WriteLine("3.  f(t) = e^(at)");
			Console.WriteLine("4.  f(t) = t^2");
			Console.WriteLine("5.  f(t) = k (constante arbitraria)");
			Console.WriteLine("6.  f(t) = e^(-at)");
			Console.WriteLine("7.  f(t) = t * e^(at)");
			Console.WriteLine("8.  f(t) = sin(at)");
			Console.WriteLine("9.  f(t) = cos(at)");
			Console.WriteLine("10. f(t) = t^n");
			Console.Write("\nIngrese el número de la opción (1-10): ");

			// Validar que el usuario ingrese un número del 1 al 10

			if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 10)
			{
				Console.WriteLine("Opción no válida. Finalizando programa.");
				return;
			}

			// // Definir función f(t)
			// Identificar la función ingresada, sus términos y tipo de función

			switch (opcion)
			{
				case 1: funcion = "1"; break;
				case 2: funcion = "t"; break;
				case 3:
					Console.Write("Ingrese el valor o variable de 'a' (ejemplo: 2 o a): ");
					valorConstante = Console.ReadLine();
					funcion = $"e^({valorConstante}t)";
					break;
				case 4: funcion = "t^2"; break;
				case 5: funcion = "k"; break;
				case 6:
					Console.Write("Ingrese el valor o variable de 'a' (ejemplo: 3 o a): ");
					valorConstante = Console.ReadLine();
					funcion = $"e^(-{valorConstante}t)";
					break;
				case 7:
					Console.Write("Ingrese el valor o variable de 'a' (ejemplo: 1 o a): ");
					valorConstante = Console.ReadLine();
					funcion = $"t * e^({valorConstante}t)";
					break;
				case 8:
					Console.Write("Ingrese la constante 'a' para sin(at): ");
					valorConstante = Console.ReadLine();
					funcion = $"sin({valorConstante}t)";
					break;
				case 9:
					Console.Write("Ingrese la constante 'a' para cos(at): ");
					valorConstante = Console.ReadLine();
					funcion = $"cos({valorConstante}t)";
					break;
				case 10: funcion = "t^n"; break;
			}

			// // Identificar variable t
			// Identificar t como variable de la función y S como variable del resultado

			Console.WriteLine($"// Función f(t) identificada: {funcion}");
			Console.WriteLine("// Variable independiente de origen: t (tiempo)");
			Console.WriteLine("// Variable de destino en el dominio transformado: s");

			// // Definición de Laplace
			// Establecer límites de 0 a infinito y aplicar la fórmula

			Console.WriteLine("[PASO 1] Definición de Laplace:");
			Console.WriteLine($"    L{{{funcion}}} = Integral de 0 a inf de [ {L} * ({funcion}) ] dt");
			Console.WriteLine($"    Reescribiendo con límite: lim(b->inf) Integral de 0 a b de [ {L} * ({funcion}) ] dt\n");

			// // Sustituir y Multiplicar
			// Sustituir f(t) en la integral y simplificar la expresión

			Console.WriteLine("[PASO 2] Sustituir y Multiplicar:");
			Console.WriteLine($"    Expresión combinada dentro del integrando: {L} * ({funcion})\n");

			// // Resolver la integral respecto a t
			// Identificar el método de integración y calcular la antiderivada

			Console.WriteLine("[PASO 3] Resolver la integral respecto a t:");
			string antiderivada = "";

			switch (opcion)
			{
				case 1: // f(t) = 1

					Console.WriteLine("    -> Tipo: Integración directa de exponencial.");
					Console.WriteLine($"    -> Antiderivada obtenida: {L2}");
					antiderivada = L2;
					resultadoF_s = "1 / s";
					break;

				case 2: // f(t) = t

					Console.WriteLine("    -> Tipo: Integración por partes (u = t, dv = e^(-st) dt).");
					Console.WriteLine("    -> Antiderivada obtenida: -(t/s)e^(-st) - (1/s^2)e^(-st)");
					antiderivada = "-(t/s)e^(-st) - (1/s^2)e^(-st)";
					resultadoF_s = "1 / s^2";
					break;

				case 3: // f(t) = e^(at)

					Console.WriteLine("    -> Tipo: Suma de exponentes e^((a-s)t).");
					Console.WriteLine($"    -> Antiderivada obtenida: (1/({valorConstante}-s)) * e^(({valorConstante}-s)t)");
					antiderivada = $"(1/({valorConstante}-s)) * e^(({valorConstante}-s)t)";
					resultadoF_s = $"1 / (s - {valorConstante})";
					break;

				case 4: // f(t) = t^2

					Console.WriteLine("    -> Tipo: Integración por partes iterada (2 veces).");
					Console.WriteLine("    -> Antiderivada obtenida: -(t^2/s)e^(-st) - (2t/s^2)e^(-st) - (2/s^3)e^(-st)");
					antiderivada = "-(t^2/s)e^(-st) - (2t/s^2)e^(-st) - (2/s^3)e^(-st)";
					resultadoF_s = "2 / s^3";
					break;

				case 5: // f(t) = k

					Console.WriteLine("    -> Tipo: Sacar constante k fuera de la integral.");
					Console.WriteLine("    -> Antiderivada obtenida: k * [-(1/s)e^(-st)]");
					antiderivada = "-k * (1/s)e^(-st)";
					resultadoF_s = "k / s";
					break;

				case 6: // f(t) = e^(-at)

					Console.WriteLine("    -> Tipo: Factorización de exponente e^(-(s+a)t).");
					Console.WriteLine($"    -> Antiderivada obtenida: -(1/(s+{valorConstante})) * e^(-(s+{valorConstante})t)");
					antiderivada = $"-(1/(s+{valorConstante})) * e^(-(s+{valorConstante})t)";
					resultadoF_s = $"1 / (s + {valorConstante})";
					break;

				case 7: // f(t) = t * e^(at)

					Console.WriteLine("    -> Tipo: Integración por partes combinada con exponencial.");
					antiderivada = $"-(t/(s-{valorConstante}))e^(-(s-{valorConstante})t) - (1/(s-{valorConstante})^2)e^(-(s-{valorConstante})t)";
					resultadoF_s = $"1 / (s - {valorConstante})^2";
					break;

				case 8: // f(t) = sin(at)

					Console.WriteLine("    -> Tipo: Integración por partes cíclica.");
					antiderivada = $"[-e^(-st) * (s*sin({valorConstante}t) + {valorConstante}*cos({valorConstante}t))] / (s^2 + {valorConstante}^2)";
					resultadoF_s = $"{valorConstante} / (s^2 + {valorConstante}^2)";
					break;

				case 9: // f(t) = cos(at)

					Console.WriteLine("    -> Tipo: Integración por partes cíclica.");
					antiderivada = $"[-e^(-st) * (s*cos({valorConstante}t) - {valorConstante}*sin({valorConstante}t))] / (s^2 + {valorConstante}^2)";
					resultadoF_s = $"s / (s^2 + {valorConstante}^2)";
					break;

				case 10: // f(t) = t^n

					Console.WriteLine("    -> Tipo: Reducción por inducción / Función Gamma.");
					antiderivada = "[-e^(-st) * Sumatoria_k( (n!/k!) * t^k / s^(n-k+1) )]";
					resultadoF_s = "n! / s^(n+1)";
					break;
			}

			Console.WriteLine();

			// con los algoritmos y pseudocodigo se va armando la estructura para que no cometa errores ssy se pueda seguir paso a paso el proceso de la transformada de Laplace

			// // Evaluar los límites
			// Sustituir t por limite superior b e inferior 0

			Console.WriteLine("[PASO 4] Evaluar los límites (de 0 a b):");
			Console.WriteLine("    1. Sustituir t por b en la antiderivada: [Evaluado en b]");
			Console.WriteLine("    2. Sustituir t por 0 en la antiderivada: [Evaluado en 0]");
			Console.WriteLine("    3. Aplicar propiedad e^0 = 1 y anular términos multiplicados por t = 0.");
			Console.WriteLine("    4. Estructurar resta: [Límite Superior(b)] - [Límite Inferior(0)]\n");

			// // Evaluar Lim b-> ∞
			// Aplicar la regla de límites exponenciales al infinito

			Console.WriteLine("[PASO 5] Evaluar Lim b -> ∞:");
			Console.WriteLine("    -> Regla del límite: lim(b->inf) e^(-sb) = 0");
			Console.WriteLine("    -> Los términos en el Límite Superior que contienen e^(-sb) se vuelven 0.");
			Console.WriteLine("    -> Expresión resultante: 0 - [Límite Inferior Evaluado en 0]\n");

			// // Obtener F(s)
			// Realizar resta final y simplificar mediante ley de signos

			Console.WriteLine("[PASO 6] Obtener F(s):");
			Console.WriteLine("    -> Aplicar ley de signos (- * - = +) al restar el Límite Inferior.");


			// CAMBIAR COLOR A ROJO PARA EL RESULTADO

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"   RESULTADO FINAL:  F(s) = {resultadoF_s}");
			Console.ResetColor(); // REGRESAR AL COLOR NORMAL DE LA CONSOLA


			Console.WriteLine("Presione cualquier tecla para salir...");
			Console.ReadKey();
		}
	}
}