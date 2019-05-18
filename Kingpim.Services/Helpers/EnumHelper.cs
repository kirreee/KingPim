using Kingpim.DAL.Enums;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using ValueType = Kingpim.DAL.Enums.ValueType;

namespace Kingpim.Services.Helpers
{
    public static class EnumHelper
    {
        public static List<ValueTypeViewModel> GetListOfValueTypes()
        {
            var valueTypeViewModels = new List<ValueTypeViewModel>
            {
                new ValueTypeViewModel()
                {
                    ValueTypeId = 1,
                    ValueType = "string"
                },

                new ValueTypeViewModel()
                {
                    ValueTypeId = 2,
                    ValueType = "int"
                },

                new ValueTypeViewModel()
                {
                    ValueTypeId = 3,
                    ValueType = "bool"
                },

                new ValueTypeViewModel()
                {
                    ValueTypeId = 4,
                    ValueType = "Double"
                }
            };

            return valueTypeViewModels;
        }

        public static string EnumValueTypeToString(ValueType valueType)
        {
            switch ((int)valueType)
            {
                case 1:
                    return "String";
                case 2:
                    return "Int";
                case 3:
                    return "Bool";
                case 4:
                    return "Double";
                default:
                    return "Har ingen valuetype";
            }
        }

        public static ValueType GetValueType(int valueTypeId)
        {
            switch (valueTypeId)
            {
                case 1:
                    return ValueType.String;
                case 2:
                    return ValueType.Int;
                case 3:
                    return ValueType.Bool;
                case 4:
                    return ValueType.Double;
                default: return ValueType.String;
            }
        }


        public static List<MediaTypeViewModel> GetListOfMediatypes()
        {
            var valueTypeViewModels = new List<MediaTypeViewModel>
            {
                new MediaTypeViewModel()
                {
                    MediaType = "Manual"
                },

                new MediaTypeViewModel()
                {
                    MediaTypeTypeId = 2,
                    MediaType = "Sparepart"
                },

                new MediaTypeViewModel()
                {
                    MediaTypeTypeId = 3,
                    MediaType = "Other"
                },

            };

            return valueTypeViewModels;
        }

        public static MediaType GetMediaType(int mediaTypeId)
        {
            switch (mediaTypeId)
            {
                case 1:
                    return DAL.Enums.MediaType.Manual;
                case 2:
                    return DAL.Enums.MediaType.Sparepart;
                case 3:
                    return DAL.Enums.MediaType.Other;

                default: return DAL.Enums.MediaType.Other;
            }
        }
    }
}
