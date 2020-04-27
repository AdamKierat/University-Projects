

package com.company;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;

public class Main {
    public Main() {
    }

    public static void main(String[] args) throws IOException {
        String[] input = new String[50];
        String[] rok = new String[50];
        String[] miesiac = new String[50];
        String[] dzien = new String[50];
        int[] rok_int = new int[50];
        int[] miesiac_int = new int[50];
        int[] dzien_int = new int[50];
        int licznik = 0;

        try {
            BufferedReader reader = new BufferedReader(new FileReader("input.txt"));

            for(String line = reader.readLine(); line != null; ++licznik) {
                input[licznik] = line;
                line = reader.readLine();
            }

            reader.close();
        } catch (IOException var12) {
            var12.printStackTrace();
        }

        for(int i = 0; i < licznik; ++i) {
            rok[i] = input[i].substring(0, 7);
            miesiac[i] = input[i].substring(7, 11);
            dzien[i] = input[i].substring(11, 16);
            rok_int[i] = Integer.parseInt(rok[i], 2) + 1980;
            miesiac_int[i] = Integer.parseInt(miesiac[i], 2);
            dzien_int[i] = Integer.parseInt(dzien[i], 2);
        }

        PrintWriter zapis = new PrintWriter("output.txt");

        for(int j = 0; j < licznik - 1; ++j) {
            zapis.println(rok_int[j] + "-" + miesiac_int[j] + "-" + dzien_int[j]);
        }

        zapis.close();
    }
}
