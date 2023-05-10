using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HireEmployee : MonoBehaviour
{
    [SerializeField] private HRManagment hRManagment;

    [SerializeField] private Image currentEmployeePhoto;
    [SerializeField] private TMP_Text currentEmployeeName;

    [SerializeField] private Image hireEmployeePhoto;
    [SerializeField] private TMP_Text hireEmployeeName;
    private Worker worker;

    [SerializeField] private Button hireButton;
    public void EmployeeHiring(AbstractBuilding abstractBuilding)
    {
        hireEmployeePhoto.sprite = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].employeePhoto;
        hireEmployeeName.text = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].name;
        if (abstractBuilding.managerID != 0)
        {
            currentEmployeePhoto.sprite = hRManagment.jsonReader.emplyees.worker[abstractBuilding.managerID].employeePhoto;
            currentEmployeeName.text = hRManagment.jsonReader.emplyees.worker[abstractBuilding.managerID].name;
            //hireEmployeePhoto = hRManagment.jsonReader.emplyees.employee[hRManagment.employeeID].managerPhoto;
        }

        hireButton.onClick.RemoveAllListeners();
        hireButton.onClick.AddListener(delegate()
        {
            abstractBuilding.OnManagerSet(hRManagment.employeeID);
            //move data from one dictionary to anothrt then save file
            hRManagment.isManager = false;
            hRManagment.jsonReader.emplyees.worker.Add(hRManagment.employeeID, new Worker
            {
                name = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].name,
                photoUrl = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].photoUrl,
                employeePhoto = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].employeePhoto,
                bio = hRManagment.jsonReader.emplyees.candidate[hRManagment.employeeID].bio
            });
            hRManagment.jsonReader.emplyees.candidate.Remove(hRManagment.employeeID);
            
            hRManagment.jsonReader.SaveToFile();
            
            //hRManagment.jsonReader.emplyees.candidate.Remove(hRManagment.employeeID);

        });
    }
}

