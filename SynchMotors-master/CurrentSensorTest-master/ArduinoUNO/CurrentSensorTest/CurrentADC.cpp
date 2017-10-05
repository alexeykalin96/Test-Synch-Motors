#include "CurrentADC.h"
#include <avr/io.h>
#include <math.h>

volatile int16_t CurrentADC::count_ADCL = 0;
volatile int16_t CurrentADC::count_ADCH = 0;
volatile int16_t CurrentADC::buffer_ADC1[100];
volatile int16_t CurrentADC::buffer_ADC2[100];
volatile int16_t CurrentADC::counter_ADC1 = 0;
volatile int16_t CurrentADC::counter_ADC2 = 0;
volatile int32_t CurrentADC::summa = 0;
volatile int16_t CurrentADC::data_ADC1 = 512;
volatile int16_t CurrentADC::data_ADC2 = 512;
volatile int16_t CurrentADC::current_ADC = 0;

void CurrentADC::Init_ADC(void)
{
	ADMUX = (0 << REFS1)|(1 << REFS0)|(0 << ADLAR)|(0 << MUX3)|(0 << MUX2)|(0 << MUX1)|(0 << MUX0);
	ADCSRA = (1 << ADEN)|(1 << ADSC)|(1<<ADIE)|(1 << ADPS2)|(1 << ADPS1)|(1 << ADPS0);
}

void CurrentADC::deInit_ADC(void)
{
	ADCSRA &= ~((1 << ADEN)|(1<<ADIE));
}

void CurrentADC::ADC_INTERRUPT(void)
{
	if(((ADMUX & (1 << MUX0)) == 0))
	{
		count_ADCL = ADCL;
		count_ADCH = ADCH;
		buffer_ADC1[counter_ADC1] = (count_ADCH << 8)|(count_ADCL);
		if(counter_ADC1 == 99)
		{
			for(int i = 0; i < 100; i++)
			{
				summa += buffer_ADC1[i];
			}
			data_ADC1 = summa / 100;
			summa = 0;
			counter_ADC1 = 0;
		}
		counter_ADC1++;
		ADMUX |= (1 << MUX0);
	}
	else if((ADMUX & (1 << MUX0)) == 1)
	{
		count_ADCL = ADCL;
		count_ADCH = ADCH;
		buffer_ADC2[counter_ADC2] = (count_ADCH << 8)|(count_ADCL);
		if(counter_ADC2 == 99)
		{
			for(int i = 0; i < 100; i++)
			{
				summa += buffer_ADC2[i];
			}
			data_ADC2 = summa / 100;
			summa = 0;
			counter_ADC2 = 0;
		}
		counter_ADC2++;
		ADMUX &= ~(1 << MUX0);
	}
	
	ADCSRA |= (1 << ADSC);//запускаем очередное преобразование	
}

int16_t CurrentADC::getADC(uint8_t group)
{
	switch(group)
	{
		case 0:
		current_ADC = fabs(26.4*(data_ADC1 - 512));
		break;
		
		case 1:
		current_ADC = fabs(26.4*(data_ADC2 - 512));
		break;
	}
	return current_ADC;
}

