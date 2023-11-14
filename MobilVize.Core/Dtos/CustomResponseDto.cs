using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobilVize.Core.Dtos
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public IEnumerable<T> Datas { get; set; }
        

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int status, T data) { 
            return new CustomResponseDto<T> { StatusCode = status, Data = data };
        }
        public static CustomResponseDto<T> Success(int status)
        {
            return new CustomResponseDto<T> { StatusCode = status};
        }

        public static CustomResponseDto<T> Success(int status,IEnumerable<T> datas)
        {
            return new CustomResponseDto<T> { StatusCode = status, Datas = datas };
        }


        public static CustomResponseDto<T> Fail(int status, string error) {  return new CustomResponseDto<T> { StatusCode = status, Errors = new List<string> { error} }; }

        public static CustomResponseDto<IEnumerable<T>> ENumerableFail(int status, string error) 
        { return new CustomResponseDto<IEnumerable<T>> 
        { 
            StatusCode = status, Errors = new List<string> { error } 
        }; 
        }
    }
}
