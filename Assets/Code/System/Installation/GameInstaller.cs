using Code.InputControlling;
using Code.Multimeter;
using Code.System.Updating;
using Code.Ui;
using UnityEngine;

namespace Code.System.Installation
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameUpdate _gameUpdate;
        [SerializeField] private MultimeterView _multimeterView;
        [SerializeField] private MultimeterWindow _multimeterWindow;
        [SerializeField] private MultimeterSettings _multimeterSettings;
        
        private MultimeterModel _multimeterModel;
        private MultimeterController _multimeterController;
        private ScrollHandler _scrollHandler;

        private void Awake()
        {
            InstallScrollHandler();
            InstallMultimeter();
        }

        private void InstallScrollHandler()
        {
            _scrollHandler = new ScrollHandler();
            _gameUpdate.AddUpdatableObject(_scrollHandler);
        }

        private void InstallMultimeter()
        {
            _multimeterModel = new MultimeterModel();
            _multimeterModel.Init(_multimeterSettings);

            _multimeterController = new MultimeterController(_multimeterModel,
                _multimeterView, _multimeterWindow, _scrollHandler);
            _multimeterController.Init();
        }

        private void OnDestroy()
        {
            _multimeterController.Dispose();
        }
    }
}