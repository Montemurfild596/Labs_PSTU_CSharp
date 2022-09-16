using System;

namespace Lab_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            float a_1 = 100f, b_1 = 0.001f;
            double a_2 = 100, b_2 = 0.001;
            float A_cube_difference_f = MathF.Pow(a_1 - b_1, 3); //(a - b)^3
            float B_cube_a_f = MathF.Pow(a_1, 3); // a^3
            float C_3abSquare_f = 3 * a_1 * b_1 * b_1; //3ab^2
            float D_B_plus_C_f = B_cube_a_f + C_3abSquare_f; // a^3 + 3ab^2
            float E_A_dif_D_f = A_cube_difference_f - D_B_plus_C_f; // (a - b)^3 - (a^3 + 3ab^2)
            float F_minus3aSquareb_f = (-3) * a_1 * a_1 * b_1; // -3a^2b
            float G_cube_b_f = MathF.Pow(b_1, 3); // b^3
            float H_F_dif_G_f = F_minus3aSquareb_f - G_cube_b_f; // -3a^2b - b^3
            float result_f = E_A_dif_D_f / H_F_dif_G_f; // x / y

            double A_cube_difference_d = Math.Pow(a_2 - b_2, 3); //(a - b)^3
            double B_cube_a_d = Math.Pow(a_2, 3); // a^3
            double C_3abSquare_d = 3 * a_2 * b_2 * b_2; //3ab^2
            double D_B_plus_C_d = B_cube_a_d + C_3abSquare_d; // a^3 + 3ab^2
            double E_A_dif_D_d = A_cube_difference_d - D_B_plus_C_d; // (a - b)^3 - (a^3 + 3ab^2)
            double F_minus3aSquareb_d = (-3) * a_2 * a_2 * b_2; // -3a^2b
            double G_cube_b_d = Math.Pow(b_2, 3); // b^3
            double H_F_dif_G_d = F_minus3aSquareb_d - G_cube_b_d; // -3a^2b - b^3
            double result_d = E_A_dif_D_d / H_F_dif_G_d; // x / y

            Console.WriteLine("(a - b)^3                : " + A_cube_difference_f + " | " + A_cube_difference_d);
            Console.WriteLine("a^3                      : " + B_cube_a_f + " | " + B_cube_a_d);
            Console.WriteLine("3ab^2                    : " + C_3abSquare_f + " | " + C_3abSquare_d);
            Console.WriteLine("a^3 + 3ab^2              : " + D_B_plus_C_f + " | " + D_B_plus_C_d);
            Console.WriteLine("(a - b)^3 - (a^3 + 3ab^2): " + E_A_dif_D_f + " | " + E_A_dif_D_d);
            Console.WriteLine("-3a^2b                   : " + F_minus3aSquareb_f +" | " + F_minus3aSquareb_d);
            Console.WriteLine("b^3                      : " + G_cube_b_f + " | " + G_cube_b_d);
            Console.WriteLine("-3a^2b - b^3             : " + H_F_dif_G_f + " | " + H_F_dif_G_d);
            Console.WriteLine("Result                   : " + result_f +" | " + result_d);
        }
    }
}
