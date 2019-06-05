using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Simple
    {
        #region 1. 两数之和
        //描述：给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那【两个】整数，并返回他们的数组下标。
        //你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        //示例:
        //给定 nums = [2, 7, 11, 15], target = 9
        //因为 nums[0] + nums[1] = 2 + 7 = 9
        //所以返回[0, 1]

        /// <summary>
        /// 第一次解法(暴力解法，便利数组中的每个数据进行比较，时间复杂度为O(n^2))
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            bool isCZ = false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        isCZ = true;
                        res[0] = i;
                        res[1] = j;
                        break;
                    }
                }
                if (isCZ)
                {
                    break;
                }
            }
            return res;
        }
        //思路：使用HashMap可以将时间复杂度降低为O(n)，后面学习完数据结构中的HashMap后重新编写该算法
        #endregion

        #region 7. 整数反转
        //给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转
        //示例 1:
        //输入: 123
        //输出: 321
        //示例 2:
        //输入: -123
        //输出: -321
        //示例 3:
        //输入: 120
        //输出: 21
        /// <summary>
        /// 思路：将该正数据类型转成字符串类型，数字不是0并且最后一位是0时，去掉最后一位；再判断是否为负数，如果为负数去掉符号并反转并且在开头位置加上符号；
        /// 先将反转后的字符串转成long类型，因为有可能会超出int类型的值，将转化后的值与int的最大值和最小值比较，如果超出则返回0，否则返回对应的int型结果
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            string resStr = "";
            var xStr = x.ToString();
            if (xStr[xStr.Length - 1] == '0' && xStr.Length > 1)
            {
                xStr = xStr.Substring(0, xStr.Length - 1);
            }
            if (xStr[0] == '-')
            {
                xStr = xStr.Substring(1, xStr.Length - 1);
                resStr = "-";
                for (int i = xStr.Length - 1; i >= 0; i--)
                {
                    resStr += xStr[i];
                }
            }
            else
            {
                for (int i = xStr.Length - 1; i >= 0; i--)
                {
                    resStr += xStr[i];
                }
            }
            var res = Convert.ToInt64(resStr);
            if (res > int.MaxValue || res < int.MinValue)
            {
                return 0;
            }
            return (int)res;
        }
        #endregion

        #region 9. 回文数
        //判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。
        //示例 1:
        //输入: 121
        //输出: true
        //示例 2:
        //输入: -121
        //输出: false
        //解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
        //示例 3:
        //输入: 10
        //输出: false
        //解释: 从右向左读, 为 01 。因此它不是一个回文数。
        /// <summary>
        /// 思路：判断该整数是否为负数或者是否为非0且以0为结尾的整数，如果是以上情况则返回false；再判断是否是一位数，如果是则返回true；
        /// 然后再遍历转化为字符串的该整数，只需要遍历一半长度就可以，判断首位是否一致，不一致返回false，如果遍历完成都一致，则返回true
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            bool isPal = false;
            var xStr = x.ToString();
            if (x < 0 || (x != 0 && xStr[xStr.Length - 1] == '0'))
            {
                return false;
            }
            if (xStr.Length == 1)
            {
                return true;
            }
            for (int i = 0; i < xStr.Length / 2; i++)
            {
                if (xStr[i] != xStr[xStr.Length - 1 - i])
                {
                    isPal = false;
                    break;
                }
                else
                {
                    isPal = true;
                }
            }
            return isPal;
        }
        #endregion

        #region 13. 罗马数字转整数
        //罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。
        //字符 数值
        //I             1
        //V             5
        //X             10
        //L             50
        //C             100
        //D             500
        //M             1000
        //例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做 XXVII, 即为 XX + V + II 。
        //通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，
        //所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
        //I 可以放在 V(5) 和 X(10) 的左边，来表示 4 和 9。
        //X 可以放在 L(50) 和 C(100) 的左边，来表示 40 和 90。 
        //C 可以放在 D(500) 和 M(1000) 的左边，来表示 400 和 900。
        //给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
        //示例 1:
        //输入: "III"
        //输出: 3
        //示例 2:
        //输入: "IV"
        //输出: 4
        //示例 3:
        //输入: "IX"
        //输出: 9
        //示例 4:
        //输入: "LVIII"
        //输出: 58
        //解释: L = 50, V= 5, III = 3.
        //示例 5:
        //输入: "MCMXCIV"
        //输出: 1994
        //解释: M = 1000, CM = 900, XC = 90, IV = 4.
        /// <summary>
        /// 思路详见方法，方法内有说明
        /// 总结：思路一（204ms）比思路二（212ms）要慢上10ms左右，基本上差不多
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            int res = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('I', 1);
            dic.Add('V', 5);
            dic.Add('X', 10);
            dic.Add('L', 50);
            dic.Add('C', 100);
            dic.Add('D', 500);
            dic.Add('M', 1000);
            Dictionary<string, int> dic_zh = new Dictionary<string, int>();
            dic_zh.Add("IV", 4);
            dic_zh.Add("IX", 9);
            dic_zh.Add("XL", 40);
            dic_zh.Add("XC", 90);
            dic_zh.Add("CD", 400);
            dic_zh.Add("CM", 900);
            #region 思路一：遍历字符串，先两位一起判断是否是特殊情况，如果是就加上该值并跳过该两位，如果不是就加上该值并跳过一位，直到最后（注意：容易出错的地方时，执行到最后一位是截取两位数时，会超出数组长度报错）
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && dic_zh.Keys.Contains(s.Substring(i, 2)))
                {
                    res += dic_zh[s.Substring(i, 2)];
                    i++;
                }
                else
                {
                    res += dic[s[i]];
                }
            }
            #endregion
            #region 思路二：先将特殊的情况计算出来，并将该字符串中计算过的特殊情况字符串移除，直到完全判别完特殊情况，然后再计算剩余的非特殊情况的字符值
            //foreach (var item in dic_zh.Keys)
            //{
            //    while (s.Contains(item))
            //    {
            //        res += dic_zh[item];
            //        s = s.Replace(item, "");
            //    }
            //}
            //for (int i = 0; i < s.Length; i++)
            //{
            //    res += dic[s[i]];
            //}
            #endregion
            return res;
        }
        #endregion

        #region 14. 最长公共前缀
        //编写一个函数来查找字符串数组中的最长公共前缀。
        //如果不存在公共前缀，返回空字符串 ""。
        //示例 1:
        //输入: ["flower","flow","flight"]
        //        输出: "fl"
        //示例 2:
        //输入: ["dog","racecar","car"]
        //        输出: ""
        //解释: 输入不存在公共前缀。
        //说明:
        //所有输入只包含小写字母 a-z 。
        /// <summary>
        /// 思路详见方法，方法内有详细说明
        /// 思路一（260ms）比思路二（164ms）慢100ms左右，效率提升60%左右
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            string strRes = "";
            if (strs == null || strs.Length <= 0)
            {
                return strRes;
            }
            #region 思路一：该方案是先找到最短的字符串；然后遍历最短的字符串，根据最短的字符串判断其他字符串的开头是否一致，如果一致继续判断下一位，直到最后一位，如果不一致就跳出
            //int temp = strs[0].Length;
            //int index = 0;
            //for (int i = 0; i < strs.Length - 1; i++)
            //{
            //    if (temp > strs[i + 1].Length)
            //    {
            //        temp = strs[i + 1].Length;
            //        index = i + 1;
            //    }
            //}
            //for (int i = 0; i < strs[index].Length; i++)
            //{
            //    char c = strs[index][i];
            //    bool isEq = false;
            //    for (int j = 0; j < strs.Length; j++)
            //    {
            //        if (c != strs[j][i])
            //        {
            //            isEq = false;
            //            break;
            //        }
            //        else
            //        {
            //            isEq = true;
            //        }
            //    }
            //    if (isEq)
            //    {
            //        strRes += c;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            #endregion
            #region 思路二：不需要专门找到最短的字符串，如果该数组中只有一个值，则返回该值，否则，直接以第一个字符串为基准找相同的开头，但是要注意后面的字符串可能比第一个短，因此需要判断当前要判断的字符下标是否已经大于该字符串的长度（例如：i < strs[j].Length）
            if (strs.Length == 1)
            {
                return strs[0];
            }
            for (int i = 0; i < strs[0].Length; i++)
            {
                bool isEq = false;
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i < strs[j].Length && strs[j][i] == strs[0][i])
                    {
                        isEq = true;
                    }
                    else
                    {
                        isEq = false;
                        break;
                    }
                }
                if (isEq)
                {
                    strRes += strs[0][i];
                }
                else
                {
                    break;
                }
            }
            #endregion
            return strRes;
        }
        #endregion
    }
}
