using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OpenCirnix.Lite
{
    public static class ExtensionMethods
    {
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        #region From Bytes Array
        /// <summary>
        /// 바이트 배열의 지정된 된 위치에 바이트에서 변환 하는 부울 값을 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">내 바이트의 인덱스 <paramref name="value"/>"/>합니다.</param>
        /// <returns>true 경우에 바이트 index 에서 value 0이 아니고, 그렇지 않으면 false합니다.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        public static bool ToBoolean(this byte[] value, int index = 0) => BitConverter.ToBoolean(value, index);

        /// <summary>
        /// 변환 된 바이트 배열에 지정된 된 위치에 2 바이트에서 유니코드 문자를 반환 합니다.
        /// </summary>
        /// <param name="value">배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>2 바이트에서 시작 하 여 형성 된 문자 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 같으면 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        public static char ToChar(this byte[] value, int index = 0) => BitConverter.ToChar(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에 2 바이트에서 변환 하는 16 비트 부호 있는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 2 바이트로 형성 된 16 비트 부호 있는 정수 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 같으면 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        [SecuritySafeCritical]
        public static short ToInt16(this byte[] value, int index = 0) => BitConverter.ToInt16(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에서 4 바이트에서 변환 하는 32 비트 부호 있는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 4 바이트로 형성 된 32 비트 부호 있는 정수 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 보다 크거나 value 3,-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        [SecuritySafeCritical]
        public static int ToInt32(this byte[] value, int index = 0) => BitConverter.ToInt32(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에 8 바이트에서 변환 하는 64 비트 부호 있는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 8 바이트도 64 비트 부호 있는 정수로 구성 된 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 보다 크거나 value 7-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        [SecuritySafeCritical]
        public static long ToInt64(this byte[] value, int index = 0) => BitConverter.ToInt64(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에 2 바이트에서 변환 하는 16 비트 부호 없는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 2 바이트로 형성 된 16 비트 부호 없는 정수 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 같으면 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        public static ushort ToUInt16(this byte[] value, int index = 0) => BitConverter.ToUInt16(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에서 4 바이트에서 변환 하는 32 비트 부호 없는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 4 바이트로 형성 된 32 비트 부호 없는 정수 startIndex합니다.</returns>
        /// <exception cref="ArgumentException">startIndex길이 보다 크거나 value 3,-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        public static uint ToUInt32(this byte[] value, int index = 0) => BitConverter.ToUInt32(value, index);

        /// <summary>
        /// 바이트 배열에 지정된 된 위치에 8 바이트에서 변환 하는 64 비트 부호 없는 정수를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>시작 하는 8 바이트도 64 비트 부호 없는 정수로 구성 된 startIndex합니다.</returns>
        /// <exception cref="ArgumentException">startIndex길이 보다 크거나 value 7-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        public static ulong ToUInt64(this byte[] value, int index = 0) => BitConverter.ToUInt64(value, index);

        /// <summary>
        /// 4 바이트를 바이트 배열의 지정된 된 위치에서 변환 된 단 정밀도 부동 소수점 숫자를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>단 정밀도 부동 소수점 숫자에서 시작 하는 4 바이트로 형성 된 startIndex합니다.</returns>
        /// <exception cref="ArgumentException">startIndex길이 보다 크거나 value 7-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        [SecuritySafeCritical]
        public static float ToSingle(this byte[] value, int index = 0) => BitConverter.ToSingle(value, index);

        /// <summary>
        /// 변환 된 바이트 배열에 지정된 된 위치에 8 바이트에서 2 배 정밀도 부동 소수점 숫자를 반환 합니다.
        /// </summary>
        /// <param name="value">바이트 배열입니다.</param>
        /// <param name="index">value 내의 시작 위치입니다.</param>
        /// <returns>배정밀도 부동 소수점 숫자에서 시작 하는 8 바이트로 형성 된 index합니다.</returns>
        /// <exception cref="ArgumentException">index길이 보다 크거나 value 7-가의 길이 보다 작거나 같음 및 value 1을 뺀 값입니다.</exception>
        /// <exception cref="ArgumentNullException">value가 null인 경우</exception>
        /// <exception cref="ArgumentOutOfRangeException">index가 0 보다 작거나의 길이 보다 큰 value 1을 뺀 값입니다.</exception>
        [SecuritySafeCritical]
        public static double ToDouble(this byte[] value, int index = 0) => BitConverter.ToDouble(value, index);

        /// <summary>
        /// 파생 클래스에서 재정의되면 지정한 바이트 배열의 모든 바이트를 문자열로 디코딩합니다.
        /// </summary>
        /// <param name="bytes">디코딩할 바이트 시퀀스를 포함하는 바이트 배열입니다.</param>
        /// <returns>지정된 바이트 시퀀스에 대한 디코딩 결과가 포함된 문자열입니다.</returns>
        /// <exception cref="ArgumentException">잘못 된 유니코드 코드 포인트를 포함 하는 바이트 배열.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/>가 null인 경우</exception>
        /// <exception cref="DecoderFallbackException">대체가 발생했습니다(전체 설명은 .NET Framework의 문자 인코딩 참조). 및 <see cref="DecoderFallback"/>이 <see cref="DecoderExceptionFallback"/>로 설정됩니다.</exception>
        public static string GetString(this byte[] bytes) => DefaultEncoding.GetString(bytes);

        /// <summary>
        /// 파생 클래스에서 재정의되면 지정한 바이트 배열의 모든 바이트를 문자열로 디코딩합니다.
        /// </summary>
        /// <param name="bytes">디코딩할 바이트 시퀀스를 포함하는 바이트 배열입니다.</param>
        /// <param name="encoding">디코딩에 사용될 문자 인코더입니다.</param>
        /// <returns>지정된 바이트 시퀀스에 대한 디코딩 결과가 포함된 문자열입니다.</returns>
        /// <exception cref="ArgumentException">잘못 된 유니코드 코드 포인트를 포함 하는 바이트 배열.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/>가 null인 경우</exception>
        /// <exception cref="DecoderFallbackException">대체가 발생했습니다(전체 설명은 .NET Framework의 문자 인코딩 참조). 및 <see cref="DecoderFallback"/>이 <see cref="DecoderExceptionFallback"/>로 설정됩니다.</exception>
        public static string GetString(this byte[] bytes, Encoding encoding) => encoding.GetString(bytes);

        /// <summary>
        /// 지정된 바이트 배열을 지정된 인덱스부터 복사하여 반환합니다.
        /// </summary>
        /// <param name="array">데이터를 받아올 바이트 배열입니다.</param>
        /// <param name="StartIndex">인덱스의 시작 위치입니다.</param>
        /// <returns>바이트 배열입니다.</returns>
        public static byte[] SubArray(this byte[] array, int StartIndex)
        {
            byte[] buffer = new byte[array.Length - StartIndex];
            Array.ConstrainedCopy(array, StartIndex, buffer, 0, array.Length - StartIndex);
            return buffer;
        }

        /// <summary>
        /// 지정된 바이트 배열을 지정된 인덱스부터 지정된 길이만큼 복사하여 반환합니다.
        /// </summary>
        /// <param name="array">데이터를 받아올 바이트 배열입니다.</param>
        /// <param name="StartIndex">인덱스의 시작 위치입니다.</param>
        /// <param name="Length">복사할 배열의 길이입니다.</param>
        /// <returns>바이트 배열입니다.</returns>
        public static byte[] SubArray(this byte[] array, int StartIndex, int Length)
        {
            byte[] buffer = new byte[Length];
            Array.ConstrainedCopy(array, StartIndex, buffer, 0, Length);
            return buffer;
        }
        #endregion
    }
}
