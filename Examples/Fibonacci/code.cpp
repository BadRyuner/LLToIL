#include <cstdio>
#include <stdio.h>
#include <stdlib.h>
#include <string>

int main(int argc, char* argv[]) {
   int n, t1 = 0, t2 = 1, nextTerm = 0;

   n = atoi(argv[0]);

   printf("Fibonacci Series: ");

   for (int i = 1; i <= n; ++i) {
     // Prints the first two terms.
      if(i == 1) {
         printf(std::to_string(t1).c_str()); printf(", ");
         continue;
      }
      if(i == 2) {
         printf(std::to_string(t2).c_str()); printf(", ");
         continue;
      }
      nextTerm = t1 + t2;
      t1 = t2;
      t2 = nextTerm;
        
      printf(std::to_string(nextTerm).c_str()); printf(", ");
   }
   return 0;
}