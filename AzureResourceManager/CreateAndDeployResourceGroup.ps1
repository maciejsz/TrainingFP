#Switch-AzureMode AzureResourceManager
#Add-AzureAccount

New-AzureResourceGroup -name "acptArmDeployed" -Location "WestEurope"

New-AzureResourceGroupDeployment -ResourceGroupName "acptArmDeployed" -TemplateFile ".\ConstructionProgressTrackerResources.json" -websiteName "acptarmdeployed"
