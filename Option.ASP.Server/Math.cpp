#include "pch.h"
#include "Math.h"
#include <iostream>
#include <memory>


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
	cout << "The inverse square root of 25 is " << Q_rsqrt(25) << " or almost ..." << endl;
	cout << execute() << endl;
	cout << get_route() << endl;
	return 0;
}


char* execute() {
	return (char*)"test";
}

char* get_route() {
	return (char*)"test/plugin";
}
char* get_name() {
	return (char*)"testPlugin";
}