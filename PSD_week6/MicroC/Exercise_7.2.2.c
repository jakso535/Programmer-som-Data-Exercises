// micro-C Our secound example
// Using pointer aritmetics we add 5 to 37

// run (fromFile "Exercise_7.2.2.c") [];;
// 42

void Add5(int* adr) {
  *adr = *adr + 5;
}

void main() {
  int i;
  i = 37;
  Add5(&i);
  print i;
}
