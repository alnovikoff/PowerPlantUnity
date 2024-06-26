using TMPro;
using Unity.VisualScripting;
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
        hireEmployeePhoto.sprite = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].employeePhoto;
        hireEmployeeName.text = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].name;
        if (abstractBuilding.managerID != 0)
        {
            currentEmployeePhoto.sprite = hRManagment.jsonReader.employee.worker[abstractBuilding.managerID].employeePhoto;
            currentEmployeeName.text = hRManagment.jsonReader.employee.worker[abstractBuilding.managerID].name;
            //hireEmployeePhoto = hRManagment.jsonReader.emplyees.employee[hRManagment.employeeID].managerPhoto;
        }

        hireButton.onClick.RemoveAllListeners();
        hireButton.onClick.AddListener(delegate()
        {
            abstractBuilding.OnManagerSet(hRManagment.employeeID);
            //move data from one dictionary to anothrt then save file
            hRManagment.isManager = false;
            hRManagment.jsonReader.employee.worker.Add(hRManagment.employeeID, new Worker
            {
                name = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].name,
                photoUrl = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].photoUrl,
                employeePhoto = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].employeePhoto,
                bio = hRManagment.jsonReader.employee.candidate[hRManagment.employeeID].bio
            });
            hRManagment.jsonReader.employee.candidate.Remove(hRManagment.employeeID);
            
            hRManagment.jsonReader.SaveEmployees(hRManagment.jsonReader.employee);
        });
    }
}

