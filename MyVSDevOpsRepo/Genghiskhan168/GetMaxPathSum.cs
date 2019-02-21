
class Solution {
public:
    int maxPathSum(TreeNode *root) {
        int maxSum = 0;
        int leftSum = 0;
        int rightSum = 0;
        
        if(root->left == NULL && root->right == NULL)
        {
            return root->val;
        }
        
        if(root->left != NULL)
        {
            leftSum = maxPathSum(root-->left);
            maxSum += leftSum;
            leftSum += root->val;
        }
        
        if(root->right != NULL)
        {
            rightSum = maxPathSum(root->right);
            maxSum += rightSum;
            rightSum += root->val;
        }
        
        maxSum += root->val;
        
if (maxSum > leftSum && maxSum > rightSum && maxSum > root->val)
            {
                return maxSum;
            }

            if (root->val > leftSum && root->val > rightSum)
            {
                return root->val;
            }

            if(leftSum > rightSum)
            {
                return leftSum;
            }

            return rightSum;
    }
};