using System;
using Code.Multimeter;

namespace Code.MultimeterDataWindow
{
    public class MultimeterDataWindowController: IDisposable
    {
        private MultimeterModel _multimeterModel;
        private MultimeterDataWindowView _multimeterDataWindowView;

        public MultimeterDataWindowController(MultimeterModel multimeterModel, 
            MultimeterDataWindowView multimeterDataWindowView)
        {
            _multimeterModel = multimeterModel;
            _multimeterDataWindowView = multimeterDataWindowView;
        }

        public void Init()
        {
            _multimeterModel.ResultCalculated += OnResultCalculated;
        }

        private void OnResultCalculated(float result, SectionType sectionType)
        {
            _multimeterDataWindowView.UpdateResult(result, sectionType);
        }

        public void Dispose()
        {
            _multimeterModel.ResultCalculated -= OnResultCalculated;
        }
    }
}
