using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Domain.Extensions;
using SwfLib;
using SwfLib.Data;
using SwfLib.Tags;
using SwfLib.Tags.ActionsTags;
using SwfLib.Tags.BitmapTags;
using SwfLib.Tags.ControlTags;
using SwfLib.Tags.DisplayListTags;
using SwfLib.Tags.ShapeTags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GataryLabs.SwfBox.Domain
{
    internal class SwfFileAnalyzer : ISwfFileAnalyzer
    {
        public void TestFile(string swfFilePath)
        {
            SwfFile swfFile = LoadSwfFile(swfFilePath);

            Debug.WriteLine(swfFile.FileInfo);
            Debug.WriteLine(swfFile.FileInfo.Version);
            Debug.WriteLine(swfFile.FileInfo.Format);
            Debug.WriteLine(swfFile.FileInfo.FileLength);
            Debug.WriteLine(swfFile.Header.FrameCount);
            Debug.WriteLine(swfFile.Header.FrameRate);
            Debug.WriteLine(swfFile.Header.FrameSize);
            Debug.WriteLine($"Tags({swfFile.Tags.Count}): " + swfFile.Tags.Count);

            foreach(SwfTagBase tag in swfFile.Tags)
            {
                switch(tag)
                {
                    case FileAttributesTag fileAttributesTag:
                        Debug.WriteLine(fileAttributesTag.TagType + " | " + fileAttributesTag.HasMetadata);
                        break;
                            
                    case MetadataTag metadataTa:
                        Debug.WriteLine(metadataTa.TagType + " | " + metadataTa.Metadata);
                        break;
                            
                    case EnableDebugger2Tag enableDebugger2Tag:
                        Debug.WriteLine(enableDebugger2Tag.TagType + " | " + enableDebugger2Tag.Data);
                        break;
                            
                    case ScriptLimitsTag scriptLimitsTag:
                        Debug.WriteLine(scriptLimitsTag.TagType + " | " + scriptLimitsTag.MaxRecursionDepth + " | " + scriptLimitsTag.ScriptTimeoutSeconds + " | " + scriptLimitsTag.RestData);
                        break;

                    case SetBackgroundColorTag setBackgroundColorTag:
                        Debug.WriteLine(setBackgroundColorTag.TagType + " | " + setBackgroundColorTag.Color + " | " + setBackgroundColorTag.RestData);
                        break;
                            
                    case FrameLabelTag frameLabelTag:
                        Debug.WriteLine(frameLabelTag.TagType + " | " + frameLabelTag.AnchorFlag + " | " + frameLabelTag.Name + " | " + frameLabelTag.RestData);
                        break;

                    case DefineShapeTag defineShapeTag:
                        Debug.WriteLine(defineShapeTag.TagType + " | " + defineShapeTag.FillStyles + " | " + defineShapeTag.ShapeID + " | " + defineShapeTag.ShapeBounds);
                        break;
                            
                    case DefineSpriteTag defineSpriteTag:
                        Debug.WriteLine(defineSpriteTag.TagType + " | " + defineSpriteTag.FramesCount + " | " + defineSpriteTag.SpriteID + " | " + defineSpriteTag.Tags);
                        break;
                            
                    case DefineBitsLossless2Tag defineBitsLossless2Tag:
                        Debug.WriteLine(defineBitsLossless2Tag.TagType + " | " + defineBitsLossless2Tag.BitmapColorTableSize + " | " + defineBitsLossless2Tag.BitmapFormat + " | " + defineBitsLossless2Tag.BitmapWidth + " x " + defineBitsLossless2Tag.BitmapHeight);
                        break;
                            
                    case ExportAssetsTag exportAssetsTag:
                        Debug.WriteLine(exportAssetsTag.TagType + " | " + exportAssetsTag.Symbols);
                        foreach (SwfSymbolReference symbol in exportAssetsTag.Symbols)
                        {
                            Debug.WriteLine("- " + symbol.SymbolID + " | " + symbol.SymbolName);
                        }
                        break;
                            
                    case DoABCTag doAbcTag:
                        Debug.WriteLine(doAbcTag.TagType + " | " + doAbcTag.Name + " | " + doAbcTag.Flags + " | " + doAbcTag.RestData);
                        break;

                    case SymbolClassTag symbolClassTag:
                        Debug.WriteLine(symbolClassTag.TagType + " | " + symbolClassTag.References.Count + " | " + symbolClassTag.RestData);
                        foreach (SwfSymbolReference symbolReference in symbolClassTag.References)
                        {
                            Debug.WriteLine("- " + symbolReference.SymbolID + " | " + symbolReference.SymbolName);
                        }
                        break;

                    case ShowFrameTag showFrameTag:
                        Debug.WriteLine(showFrameTag.TagType);
                        break;

                    case EndTag endTag:
                        Debug.WriteLine(endTag.TagType + " | " + endTag.RestData);
                        break;

                    case UnknownTag unknownTag:
                        Debug.WriteLine(unknownTag.TagType + " | " + unknownTag.Data + " | " + unknownTag.RestData);
                        break;

                    default:
                        Debug.WriteLine(tag.TagType + " | " + tag.RestData);
                        break;
                }
            }
        }

        public SwfAnalysisInfo AnalyzeSwfFile(string swfFilePath)
        {
            SwfFile swfFile = LoadSwfFile(swfFilePath);

            SwfAnalysisInfo result = AnalyzeSwfFile(swfFile);

            return result;
        }

        private SwfAnalysisInfo AnalyzeSwfFile(SwfFile swfFile)
        {
            SwfAnalysisInfo result = new SwfAnalysisInfo();

            result.Info = DescribeInfoProperties(swfFile);
            
            result.Tags = swfFile.Tags
                .Select(DescribeTag)
                .ToList();

            return result;
        }

        private SwfAnalysisBasicInfo DescribeInfoProperties(SwfFile swfFile)
        {
            SwfAnalysisBasicInfo result = new SwfAnalysisBasicInfo();

            result.FlashPlayerVersion = swfFile.FileInfo.Version;
            result.SwfFormat = swfFile.FileInfo.Format.ToString();
            result.FileLength = swfFile.FileInfo.FileLength;
            result.FrameRate = swfFile.Header.FrameRate;
            result.FrameCount = swfFile.Header.FrameCount;
            result.FrameSize = swfFile.Header.FrameSize.ToString();

            return result;
        }

        private AnalysisPropertyInfo DescribeTag(SwfTagBase tag)
        {
            return DescribeAnything(tag.TagType.ToString(), tag);
        }

        private AnalysisPropertyInfo DescribeAnything(string name, object anyObject)
        {
            AnalysisPropertyInfo resultProperty = new AnalysisPropertyInfo();
            resultProperty.Name = name;
            resultProperty.RawValue = anyObject;

            Type type = anyObject?.GetType();

            if (type?.IsPrimitive ?? true)
            {
                resultProperty.Name += " = " + anyObject;
                return resultProperty;
            }
            
            if (anyObject is string stringValue)
            {
                resultProperty.Name += $" = '{stringValue}'";
                return resultProperty;
            }

            if (type?.IsEnum ?? false)
            {
                resultProperty.Name += " = " + anyObject.ToString();
                return resultProperty;
            }

            if (anyObject is IEnumerable enumerableObject)
            {
                resultProperty.Name += $" ({enumerableObject.Count()})";

                if (enumerableObject is IEnumerable<byte>)
                    resultProperty.Name += " [byte array]";
                else
                    resultProperty.Properties = DecsribeEnumerable(enumerableObject);

                return resultProperty;
            }

            resultProperty.Properties = DescribeFields(type, anyObject);
            resultProperty.Description = type.Name;

            return resultProperty;
        }

        private List<AnalysisPropertyInfo> DescribeFields(Type type, object anyObject)
        {
            PropertyInfo[] publicProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            List<AnalysisPropertyInfo> result = new List<AnalysisPropertyInfo>();

            foreach (PropertyInfo reflectiveInfo in publicProperties)
            {
                object value = reflectiveInfo.GetValue(anyObject);
                AnalysisPropertyInfo elementAsPropertyInfo = DescribeAnything(reflectiveInfo.Name, value);
                result.Add(elementAsPropertyInfo);
            }

            return result;
        }

        private List<AnalysisPropertyInfo> DecsribeEnumerable(IEnumerable enumerableObject)
        {
            List<AnalysisPropertyInfo> result = new List<AnalysisPropertyInfo>();

            foreach (object element in enumerableObject)
            {
                Type elementType = element?.GetType();
                string name = elementType?.Name ?? "";
                AnalysisPropertyInfo elementAsPropertyInfo = DescribeAnything(name, element);
                result.Add(elementAsPropertyInfo);
            }

            return result;
        }

        private SwfFile LoadSwfFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                SwfFile swfFile = SwfFile.ReadFrom(reader.BaseStream);
                return swfFile;
            }
        }
    }
}
