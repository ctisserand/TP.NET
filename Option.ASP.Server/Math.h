#pragma once


#ifdef _WIN32
#    ifdef LIBRARY_EXPORTS
#        define LIBRARY_API __declspec(dllexport)
#    else
#        define LIBRARY_API __declspec(dllimport)
#    endif
#elif
#    define LIBRARY_API
#endif

#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)



using namespace std;
EXTERN_DLL_EXPORT float Q_rsqrt(float number);

EXTERN_DLL_EXPORT char* execute();

EXTERN_DLL_EXPORT char* get_route();

EXTERN_DLL_EXPORT char* get_name();