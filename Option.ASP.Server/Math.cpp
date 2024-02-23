#include "pch.h"
#include "Math.h"



using namespace std;
float Q_rsqrt(float number) {
	long i;
	float x2, y;
	const float threehalfs = 1.5F;

	x2 = number * 0.5F;
	y = number;
	i = *(long*)&y; // evil floating point bit level hacking
	i = 0x5f3759df - (i >> 1); // what the fuck?
	y = *(float*)&i;
	y = y * (threehalfs - (x2 * y * y)); // 1st iteration
	//	y = y * ( threehalfs - ( x2 * y * y ) ); // 2nd iteration, this can be removed

	return y;
}

// 
int main() {
	cout << execute() << endl;
	return 0;
}


char* execute() {
	stringstream s;
	s << "The inverse square root of 25 is ";
	s << Q_rsqrt(25); // appending the float value to the streamclass 
	s << " or almost ...";
	string result = s.str(); //converting the float value to string 
	// Dynamically allocate memory for the returned string
	char* ptr = new char[result.size() + 1]; // +1 for terminating NUL
	// Copy source string in dynamically allocated string buffer
	strcpy_s(ptr, result.size() +1, result.c_str());
	return ptr;
}

char* get_route() {
	return (char*)"test/plugin";
}
char* get_name() {
	return (char*)"testPlugin";
}