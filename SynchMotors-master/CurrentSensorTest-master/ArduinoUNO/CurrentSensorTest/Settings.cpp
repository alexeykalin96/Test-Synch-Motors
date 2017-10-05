#include "Settings.h"
#include <avr/io.h>
#include <avr/eeprom.h>

void Settings::writeToEeprom(uint16_t* data)
{
	for(uint8_t i = 0; i < 3; i++)
	{
		for(uint8_t j = i*6; j < i*6+6; j+=2)
		{
			eeprom_write_word((uint16_t*)j, *(data + i));
		}
	}
}

uint16_t* Settings::readFromEepromForAnalysis(void)
{
	for(uint8_t i = 0; i < 3; i++)
	{
		if(eeprom_read_word((uint16_t*)(i*6)) == eeprom_read_word((uint16_t*)(i*6)+2))
		{
			motorSettingsForAnalysis[i] = eeprom_read_word((uint16_t*)(i*6));
		}
		else if(eeprom_read_word((uint16_t*)(i*6)) == eeprom_read_word((uint16_t*)(i*6)+4))
		{
			motorSettingsForAnalysis[i] = eeprom_read_word((uint16_t*)(i*6));
		}
		else if(eeprom_read_word((uint16_t*)(i*6)+2) == eeprom_read_word((uint16_t*)(i*6)+4))
		{
			motorSettingsForAnalysis[i] = eeprom_read_word((uint16_t*)(i*6)+2);
		}
	}
	return motorSettingsForAnalysis;
}

char* Settings::readFromEepromForSend(void)
{
	motorSettingsForSend[0] = '<';
	for(uint8_t i = 0; i < 3; i++)
	{
		if(eeprom_read_word((uint16_t*)(i*6)) == eeprom_read_word((uint16_t*)(i*6)+2))
		{
			motorSettingsForSend[i*2+2] = eeprom_read_byte((uint8_t*)(i*6));
			motorSettingsForSend[i*2+1] = eeprom_read_byte((uint8_t*)(i*6)+1);
		}
		else if(eeprom_read_word((uint16_t*)(i*6)) == eeprom_read_word((uint16_t*)(i*6)+4))
		{
			motorSettingsForSend[i*2+2] = eeprom_read_byte((uint8_t*)(i*6));
			motorSettingsForSend[i*2+1] = eeprom_read_byte((uint8_t*)(i*6)+1);
		}
		else if(eeprom_read_word((uint16_t*)(i*6)+2) == eeprom_read_word((uint16_t*)(i*6)+4))
		{
			motorSettingsForSend[i*2+2] = eeprom_read_byte((uint8_t*)(i*6)+2);
			motorSettingsForSend[i*2+1] = eeprom_read_byte((uint8_t*)(i*6)+3);
		}
	}
	motorSettingsForSend[7] = '>';
	motorSettingsForSend[8] = '\0';
	return motorSettingsForSend;
}
