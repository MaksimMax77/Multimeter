using Code.InputControlling;
using Code.Multimeter;
using Code.MultimeterDataWindow;
using Code.System.Updating;
using UnityEngine;

namespace Code.System.Installation
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameUpdate _gameUpdate;
        [SerializeField] private MultimeterView _multimeterView;
        [SerializeField] private MultimeterDataWindowView _multimeterDataWindowView;
        [SerializeField] private MultimeterSettings _multimeterSettings;
        
        private MultimeterModel _multimeterModel;
        private MultimeterController _multimeterController;
        private MultimeterDataWindowController _multimeterDataWindowController;
        private ScrollHandler _scrollHandler;
        
        private void Awake()
        {
            InstallScrollHandler();
            InstallMultimeter();
            InstallMultimeterDataWindow();
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
                _multimeterView, _scrollHandler);
            _multimeterController.Init();
        }

        private void InstallMultimeterDataWindow()
        {
            _multimeterDataWindowController =
                new MultimeterDataWindowController(_multimeterModel, _multimeterDataWindowView);
            _multimeterDataWindowController.Init();
        }

        private void OnDestroy()
        {
            _multimeterController.Dispose();
            _multimeterDataWindowController.Dispose();
        }
    }
}