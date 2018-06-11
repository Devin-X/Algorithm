public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int start = 0;
        int end = 1;
        while(end < nums.Length)
        {
            if(nums[end] == nums[start]){
                end++;
            }else{
                nums[++start] = nums[end++];
            }
        }

        return nums.Length == 0 ? 0 : start+1;
    }

    public int RemoveElement(int[] nums, int val)
    {
        int count = 0;
        int index = 0;
        if (nums.Length == 0) return 0;
        while(index < nums.Length)
        {
            if(nums[index] == val)
            {
                count++;
            }
            else 
            {
                nums[index-count] = nums[index];
            }
            index++;
        }

        return index-count;
    }
}