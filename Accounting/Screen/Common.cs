using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Accounting.Screen
{
    class Common : UserControl
    {
        /** 
         * Check if has database validation errors, if there's any, prompt message box to users and
         * return false
         */
        public static bool hasDbValidationErrors(IEnumerable<DbEntityValidationResult> errors)
        {
            var dbEntityValidationResults = errors as DbEntityValidationResult[] ?? errors.ToArray();
            if (dbEntityValidationResults.Any())
            {
                var msg = "Unable to save data due to errors:\n";
                int errCount = 0;
                foreach (var results in dbEntityValidationResults)
                {
                    //error.ValidationErrors.ToArray()[0].ErrorMessage
                    var errorList = results.ValidationErrors.ToArray();
                    msg = errorList.Aggregate(msg, (current, err) => current + (++errCount +". [" +  err.PropertyName + "] " + err.ErrorMessage + "\n"));
                }

                MessageBox.Show(msg, "Failed to save", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }


        public static bool verifyControlValid(DependencyObject parent)
        {
            if (!IsControlValid(parent))
            {
                MessageBox.Show("Unable to save data. Please fix validation errors.", "Validation errors", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        /**
         * Check if the element control and its child elements are all valid.
         */
        public static bool IsControlValid(DependencyObject parent)
        {
            if (Validation.GetHasError(parent))
                return false;

            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!IsControlValid(child)) { return false; }
            }

            return true;
        }
    }
}
