
using System.Reflection;
using System.Text;
using System.Collections;

namespace FileOperations
{
    public class Json
    {
        private string className = "";
        private string fieldName = "";
        private string fieldValue = "";
        private List<string> fieldValueList = [];
        private Type type;

        public string ToJson(object instance)
        {
            StringBuilder builder = new();
            int counterClass = 0;
            int counterItem = 0;
            int classCount = 0;
            int itemCount = 0;
            builder.Append('{').AppendLine();

            Type type = instance.GetType();
            PropertyInfo[] classProperty = type.GetProperties();
            classCount = classProperty.Length;
            foreach (PropertyInfo property in type.GetProperties())
            {
                
                if (type.IsClass)
                {
                    builder.Append("  \"").Append(property.Name).Append('"').Append(": {").AppendLine();
                    object nestedObject = property.GetValue(instance);

                    Type nestedType = nestedObject.GetType(); // lekérjük a beágyazott osztály típusát
                    PropertyInfo[] nestedProperties = nestedType.GetProperties();
                    itemCount = nestedProperties.Length;
                    counterItem = 0;
                    foreach (PropertyInfo nestedProperty in nestedProperties) // végigmegyünk a beágyazott tulajdonságokon
                    {
                        builder.Append("    \"").Append(nestedProperty.Name).Append("\": ");

                        if (nestedProperty.PropertyType.Name == "String")
                        {
                            builder.Append('"').Append(nestedProperty.GetValue(nestedObject)?.ToString() ?? string.Empty).Append('"');
                        }
                        else //if (nestedProperty.PropertyType.Name == "Boolean")
                        {
                            builder.Append(nestedProperty.GetValue(nestedObject)?.ToString() ?? string.Empty);
                        }
                        counterItem++;
                        if (counterItem < itemCount)
                        {
                            builder.Append(',').AppendLine();
                        }
                        else
                        {
                            builder.AppendLine();
                        }
                    }
                    counterClass++;
                    if (counterClass < classCount)
                    {
                        builder.Append("  },").AppendLine();
                    }
                    else
                    {
                        builder.Append("  }").AppendLine();
                    }
                }
                else
                {
                    builder.Append('"').Append(property.Name).Append('"').Append(':').Append(property.GetValue(instance)?.ToString() ?? string.Empty).Append(',');
                }
            }

            builder.Append('}');

            return builder.ToString();

        }

        public void FromJson(object fromFields, string json)
        {
            type = fromFields.GetType();
            StringReader stringReader = new StringReader(json);
            string temp = string.Empty;

            while (true)
            {
                temp = stringReader.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(temp)) break;

                if (temp.Contains('"'))
                {
                    int index = temp.IndexOf('"');
                    if (index != -1)
                    {
                        temp = temp[(index + 1)..];
                        index = temp.IndexOf("\": ");
                        className = temp[..index];
                        if (temp.Contains('{'))
                        {
                            do
                            {
                                temp = stringReader.ReadLine() ?? string.Empty;
                                ReadValue(temp);
                                SetField(fromFields);
                            } while (!temp.Contains('}'));
                        }
                        else
                        {
                            //temp = stringReader.ReadLine();
                            ReadValue(temp);
                        }
                    }
                }
                else if (temp.Contains('}'))
                {
                    fieldName = string.Empty;
                    fieldValue = string.Empty;
                }
            };
        }

        private void ReadValue(string line)
        {
            fieldName = string.Empty;
            fieldValue = string.Empty;

            int index = line.IndexOf('"');
            if (index >= 0)
            {
                fieldName = line[(index + 1)..];
                index = fieldName.IndexOf("\": ");
                int temp = 3;
                if (index == -1)
                {
                    index = fieldName.IndexOf("\":");
                    temp = 2;
                }
                fieldValue = fieldName[(index + temp)..];

                if (index != -1)
                {
                    fieldName = fieldName[..index];

                    index = fieldValue.IndexOf('"');

                    if (index != -1)
                    {
                        fieldValue = fieldValue[(index + 1)..];
                        index = fieldValue.IndexOf('"');
                        fieldValue = fieldValue[..index];
                    }
                    else
                    {
                        index = fieldValue.IndexOf(',');
                        if (index >= 0)
                        {
                            fieldValue = fieldValue[..index];
                        }
                        else
                        {
                            index = fieldValue.IndexOf('}');
                            if (index >= 0)
                            {
                                fieldValue = fieldValue[..index];
                            }
                        }
                    }
                }
            }
        }

        private void SetField(object fromFields)
        {
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object nestedObject = null;
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    if (property.Name.ToLower() == className.ToLower())
                    {
                        if (property.Name.ToLower() == "data")
                        {
                            Type elementType = property.PropertyType.GetGenericArguments()[0]; // ez a RegDatas típusa
                            IList nestedList = (IList)property.GetValue(fromFields); // ez a meglévő RegDatas objektumok listája
                            nestedObject = Activator.CreateInstance(elementType); // ez egy új RegDatas objektum
                            PropertyInfo[] elementProperties = elementType.GetProperties(); // ezek a RegDatas tulajdonságai
                            if (fieldValueList.Count > 0)
                            {
                                foreach (PropertyInfo nestedProperty in elementProperties)
                                {
                                    for (int i = 0; i < fieldValueList.Count; i += 2)
                                    {
                                        if (nestedProperty.Name.ToLower() == fieldValueList[i].ToLower())
                                        {
                                            object value = Convert.ChangeType(fieldValueList[i + 1], nestedProperty.PropertyType);
                                            nestedProperty.SetValue(nestedObject, value); // itt beállítjuk az értéket a nestedProperty-re
                                            break;
                                        }
                                    }
                                }
                                nestedList.Add(nestedObject); // itt hozzáadjuk az új objektumot a listához
                            }
                        }
                        else
                        {
                            nestedObject = property.GetValue(fromFields);
                            property.SetValue(fromFields, nestedObject); // beállítjuk az objektumot a tulajdonságra
                            Type nestedType = nestedObject.GetType(); // lekérjük a beágyazott osztály típusát
                            PropertyInfo[] nestedProperties = nestedType.GetProperties();
                            foreach (PropertyInfo nestedProperty in nestedProperties) // végigmegyünk a beágyazott tulajdonságokon
                            {
                                if (fieldName.ToLower() == nestedProperty.Name.ToLower())
                                {
                                    object value = Convert.ChangeType(fieldValue, nestedProperty.PropertyType);
                                    nestedProperty.SetValue(nestedObject, value); // beállítjuk az értéket a beágyazott tulajdonságra
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (fieldName.ToLower() == property.Name.ToLower())
                    {
                        object value = Convert.ChangeType(fieldValue, property.PropertyType);
                        property.SetValue(fromFields, value);
                        break;
                    }
                }
            }
        }

        public void ReadFromOneLine(object fromFields, string response)
        {
            type = fromFields.GetType();
            int comaIndex = -1;
            int bracesIndex = -1;
            int squareBracketIndex = -1;
            string cutted = string.Empty;
            cutted = response.Substring(1, response.Length - 2);

            do
            {
                comaIndex = cutted.IndexOf(',');
                bracesIndex = cutted.IndexOf('{');
                squareBracketIndex = cutted.IndexOf('[');

                int firstLetter = FirstLetter(comaIndex, bracesIndex, squareBracketIndex);

                if (firstLetter >= 0)
                {
                    if (firstLetter == comaIndex)
                    {
                        ReadValue(cutted[..comaIndex]);
                        SetField(fromFields);
                        cutted = cutted[(comaIndex + 1)..];
                    }
                    else if (firstLetter == bracesIndex)//'{'
                    {
                        int tmpIdx = cutted.IndexOf('}');
                    }
                    else if (firstLetter == squareBracketIndex)//'['
                    {
                        int tmpIdx = cutted.IndexOf("]");
                        ReadToList(fromFields, cutted.Substring(0, tmpIdx));
                        SetField(fromFields);
                        cutted = cutted.Substring(tmpIdx + 1);
                    }
                }
                else
                {
                    ReadValue(cutted);
                    SetField(fromFields);
                    cutted = string.Empty;
                }
            } while (cutted.Length >= 6);
        }

        private int FirstLetter(int comaIndex, int bracesIndex, int squareBracketIndex)
        {
            int min = int.MaxValue;
            int[] ints = new int[] { comaIndex, bracesIndex, squareBracketIndex };

            foreach (int i in ints)
            {
                if (i < min && i >= 0)
                {
                    min = i;
                }
            }

            if (min == int.MaxValue)
            {
                min = -1;
            }
            return min;
        }

        private void ReadToList(object fromFields, string line)
        {
            int comaIndex = line.IndexOf('\"');
            int bracesIndex = line.IndexOf('{');
            string cutted = line[(comaIndex + 1)..];
            comaIndex = cutted.IndexOf('\"');
            className = cutted[..comaIndex];
            cutted = cutted[(comaIndex + 2)..];

            do
            {
                bracesIndex = cutted.IndexOf('{');
                comaIndex = cutted.IndexOf(',');
                int firstletter = FirstLetter(comaIndex, bracesIndex, -1);
                if (firstletter == bracesIndex && firstletter >= 0)
                {
                    int endBracesIndex = cutted.IndexOf('}');
                    if (cutted.Length > endBracesIndex + 1)
                    {
                        ElementToList(cutted.Substring(bracesIndex, endBracesIndex + 1));
                        cutted = cutted[(endBracesIndex + 2)..];
                    }
                    else
                    {
                        ElementToList(cutted.Substring(bracesIndex, endBracesIndex));
                        cutted = cutted[(endBracesIndex + 1)..];
                    }
                    SetField(fromFields);
                    fieldValueList.Clear();
                }
                else
                {
                    if (comaIndex >= 0)
                    {
                        ReadValue(cutted[..comaIndex]);
                    }
                    else
                    {
                        ReadValue(cutted);
                    }
                    if (cutted.Length > 4)
                    {
                        fieldValueList.Add(fieldName);
                        fieldValueList.Add(fieldValue);
                        fieldName = string.Empty;
                        fieldValue = string.Empty;
                        if (comaIndex >= 0)
                        {
                            cutted = cutted[(comaIndex + 1)..];
                        }
                    }
                }
            } while (cutted.Length >= 6);
        }

        private void ElementToList(string line)
        {
            int index = line.IndexOf('\"');
            string cutted = line[index..];
            do
            {
                index = cutted.IndexOf("\",");
                if (index >= 0)
                {
                    ReadValue(cutted[..(index + 1)]);
                }
                else
                {
                    ReadValue(cutted);
                }
                fieldValueList.Add(fieldName);
                fieldValueList.Add(fieldValue);
                fieldName = string.Empty;
                fieldValue = string.Empty;
                if (index >= 0)
                {
                    cutted = cutted[(index + 2)..];
                }
                else
                {
                    cutted = string.Empty;
                }
            } while (cutted.Length > 6);
        }
    }
}