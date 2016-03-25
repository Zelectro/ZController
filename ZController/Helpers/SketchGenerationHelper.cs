using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZController.Helpers
{
    public static class SketchGenerationHelper
    {
        public static string GenerateSketch(Data.PilotSymbolData data, string baudRate, List<string> usedSymbolsList)
        {
            bool withTimeout = data.Enabled;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//Не забываем про подключение библиотек, если нужно");
            sb.AppendLine("//[ДОБАВИТЬ СВОЙ КОД НИЖЕ]");
            sb.AppendLine();
            if (withTimeout)
            {
                sb.AppendLine(String.Format("const int TIMEOUT_TIME_MS = {0};", (int)data.Interval * 1.5));
                sb.AppendLine("unsigned long lastPilotSymbolTime;");
            }
            sb.AppendLine("char symbol;");
            sb.AppendLine();
            sb.AppendLine("enum States");
            sb.AppendLine("{");
            sb.AppendLine("WAITING,");
            sb.AppendLine("READING,");
            sb.AppendLine("RUNNING,");
            if (withTimeout)
            {
                sb.AppendLine("ERROR,");
                sb.AppendLine("TIMEOUT");
            }
            else
            {
                sb.AppendLine("ERROR");
            }
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine("States state;");
            sb.AppendLine("States onWait();");
            sb.AppendLine("States onRead();");
            sb.AppendLine("States onRun();");
            sb.AppendLine("States onError();");
            sb.AppendLine();
            sb.AppendLine("//Место объявления ваших переменных");
            sb.AppendLine("//[ДОБАВИТЬ СВОЙ КОД НИЖЕ]");
            sb.AppendLine();
            if (withTimeout)
            {
                sb.AppendLine("States onTimeout();");
            }
            sb.AppendLine();
            sb.AppendLine("void setup()");
            sb.AppendLine("{");
            sb.AppendLine("  //Место инициализации ваших переменных");
            sb.AppendLine("  //[ДОБАВИТЬ СВОЙ КОД НИЖЕ]");
            sb.AppendLine();
            sb.AppendLine(String.Format("  Serial.begin({0});", baudRate));
            if (withTimeout)
            {
                sb.AppendLine("  lastPilotSymbolTime = 0;");
            }
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("void loop()");
            sb.AppendLine("{");
            sb.AppendLine("  switch (state)");
            sb.AppendLine("  {");
            sb.AppendLine("    case WAITING:");
            sb.AppendLine("      state = onWait();");
            sb.AppendLine("      break;");
            sb.AppendLine("    case READING:");
            sb.AppendLine("      state = onRead();");
            sb.AppendLine("      break;");
            sb.AppendLine("    case RUNNING:");
            sb.AppendLine("      state = onRun();");
            sb.AppendLine("      break;");
            if (withTimeout)
            {
                sb.AppendLine("    case TIMEOUT:");
                sb.AppendLine("      state = onTimeout();");
                sb.AppendLine("      break;");
            }
            sb.AppendLine("    default:");
            sb.AppendLine("      state = onError();");
            sb.AppendLine("  }");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("States onWait()");
            sb.AppendLine("{");
            sb.AppendLine("  if (Serial.available() > 0)");
            sb.AppendLine("  {");
            sb.AppendLine("    return READING;");
            sb.AppendLine("  }");
            if (withTimeout)
            {
                sb.AppendLine("  if (lastPilotSymbolTime && (millis() - lastPilotSymbolTime > TIMEOUT_TIME_MS))");
                sb.AppendLine("  {");
                sb.AppendLine("    return TIMEOUT;");
                sb.AppendLine("  }");
            }
            sb.AppendLine("  return WAITING;");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("States onRead()");
            sb.AppendLine("{");
            sb.AppendLine("  symbol = Serial.read();");
            sb.AppendLine("  return RUNNING;");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("States onRun()");
            sb.AppendLine("{");
            AddButtonsCases(ref sb, data, usedSymbolsList);
            sb.AppendLine("  return WAITING;");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("States onError()");
            sb.AppendLine("{");
            sb.AppendLine("  //Получены неоговоренные символы. Очищаем ввод и продолжаем.");
            sb.AppendLine("  //Здесь можно добавить какие-то действия для этой ситуации.");
            sb.AppendLine("  //...");
            sb.AppendLine("  while (Serial.available())");
            sb.AppendLine("  {");
            sb.AppendLine("    Serial.read();");
            sb.AppendLine("  }");
            sb.AppendLine("  return WAITING;");
            sb.AppendLine("}");
            sb.AppendLine();
            if (withTimeout)
            {
                sb.AppendLine("States onTimeout()");
                sb.AppendLine("{");
                sb.AppendLine("  //Действия при таймауте.");
                sb.AppendLine("  //Вероятно, связь утеряна,");
                sb.AppendLine("  //но при получении контрольного символа она будет восстановлена.");
                sb.AppendLine("  //Здесь, например, уместно выключить двигатели");
                sb.AppendLine("  //[ДОБАВИТЬ СВОЙ КОД НИЖЕ]");
                sb.AppendLine();
                sb.AppendLine("  if (Serial.available())");
                sb.AppendLine("  {");
                sb.AppendLine("    return READING;");
                sb.AppendLine("  }");
                sb.AppendLine("  return TIMEOUT;");
                sb.AppendLine("}");
            }
            return sb.ToString();
        }

        private static void AddButtonsCases(ref StringBuilder sb, Data.PilotSymbolData data, List<string> usedSymbolsList)
        {
            sb.AppendLine("  switch (symbol)");
            sb.AppendLine("  {");
            List<string> uniq = new List<string>(usedSymbolsList.Distinct());
            foreach (string symbol in uniq)
            {
                sb.AppendLine(String.Format("    case '{0}':", symbol));
                sb.AppendLine(String.Format("      //начало действий при полученном символе '{0}'", symbol));
                sb.AppendLine("      //[ДОБАВИТЬ СВОЙ КОД НИЖЕ]");
                sb.AppendLine();
                sb.AppendLine("      break;");
            }
            if (data.Enabled)
            {
                sb.AppendLine(String.Format("    case '{0}':", data.Symbol));
                sb.AppendLine("      //получили контрольный символ, не изменяйте этот код");
                sb.AppendLine("      lastPilotSymbolTime = millis();");
                sb.AppendLine("      break;");
            }
            sb.AppendLine("    default:");
            sb.AppendLine("      return ERROR;");
            sb.AppendLine("  }");
        }
    }
}
