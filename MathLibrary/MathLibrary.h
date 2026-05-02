#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define DLL_API __declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif

extern "C"
{
    DLL_API double Add(double a, double b);
    DLL_API double Subtract(double a, double b);
    DLL_API double Multiply(double a, double b);
    DLL_API double Divide(double a, double b);
}