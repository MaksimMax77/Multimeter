using System;
using Code.InputControlling;
using Code.Ui;

namespace Code.Multimeter
{
    public class MultimeterController: IDisposable
    {
        private MultimeterModel _multimeterModel;
        private MultimeterView _multimeterView;
        private MultimeterWindow _multimeterWindow;
        private ScrollHandler _scrollHandler;

        public MultimeterController(MultimeterModel multimeterModel, MultimeterView multimeterView, 
            MultimeterWindow multimeterWindow, ScrollHandler scrollHandler)
        {
            _multimeterModel = multimeterModel;
            _multimeterView = multimeterView;
            _multimeterWindow = multimeterWindow;
            _scrollHandler = scrollHandler;
        }

        public void Init()
        {
            _scrollHandler.ScrollUp += OnScrollUp;
            _scrollHandler.ScrollDown += OnScrollDown;
            _multimeterView.SectionSwitched += OnSectionSwitched;
        }

        private void OnScrollUp()
        {
            _multimeterView.OnScrollUp();
        }

        private void OnScrollDown()
        {
            _multimeterView.OnScrollDown();
        }

        private void OnSectionSwitched(SectionType sectionType)
        {
            var result = 0f;
            
            switch (sectionType)
            {
                case SectionType.Resistance:
                    result = _multimeterModel.Resistance;
                    break;
                case SectionType.AcVoltage:
                    result = _multimeterModel.ACVoltage;
                    break;
                case SectionType.CurrentPower:
                    result = _multimeterModel.CurrentPower;
                    break;
                case SectionType.DcVoltage:
                    result = _multimeterModel.DcVoltage;
                    break;
            }
            
            _multimeterView.ResultTextUpdate(result);
            _multimeterWindow.UpdateResult(result, sectionType);
        }
        
        public void Dispose()
        {
            _scrollHandler.ScrollUp -= OnScrollUp;
            _scrollHandler.ScrollDown -= OnScrollDown;
            _multimeterView.SectionSwitched -= OnSectionSwitched;
        }
    }
}
