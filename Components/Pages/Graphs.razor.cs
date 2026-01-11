using BlazorBootstrap;
using Microsoft.FSharp.Core;

namespace WebsiteFirstDraft.Components.Pages
{
    public partial class Graphs
    {
        private GraphCategories? GraphCategory;
        private GraphName? graphname;
        
        private enum GraphCategories 
        {
            BodyweightProgress,
            CalorieTracking,
            Macros,
            Hypertrophy,
            Exercise,
            Consistency
        }

        private enum GraphName
        {
            BodyweightoverTime,
            WeightChangeperWeek,
            DailyCalorieIntakevsTarget,
            Dailycaloriesurplusordeficit,
            AverageMacroDistribution,
            DailyMacroIntake,
            CaloriesBurntThroughExercise,
            ExerciseTypeFrequency,
            LoggingStreakoverTime,
            ActivityConsistency
        }

        
        // Reference to the chart component instance (initialised later)
        private LineChart? lineChart = default!;
        private BarChart? barChart = default!;

        // Configuration options for the charts
        private LineChartOptions? lineChartOptions = default!;
        private BarChartOptions? barChartOptions = default!;

        // Data model (labels + datasets) for the chart
        private ChartData chartData = default!;

        // Counter for how many datasets have been created
        private int datasetsCount;

        // Counter for how many labels (data points) have been created
        private int labelsCount;

        // Random number generator used to create sample data
        private Random random = new();

        private bool baseline = true;

        private int selectedGraph;

        private int previousGraph = -1;

        // Lifecycle method: initialize component state before rendering
        protected override void OnInitialized()
        {
            selectedGraph = (int)GraphName.BodyweightoverTime;
            InitializeSelectedGraph();
        }

        // Lifecycle method: runs after component has rendered
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender || previousGraph != selectedGraph)
            {
                previousGraph = selectedGraph;
                await InitializeChart();
            }
            
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task OnGraphSelected()
        {
            InitializeSelectedGraph();
            StateHasChanged();
            
            // Wait for the next render cycle to complete before updating
            await Task.Delay(100);
            await UpdateChart();
        }

        private void InitializeSelectedGraph()
        {
            // Reset counters
            labelsCount = 0;
            datasetsCount = 0;

            switch (selectedGraph)
            {
                case 0:
                    InitialiseBodyweightOverTimeGraph();
                    break;
                case 1:
                    InitialiseWeightChangePerWeekGraph();
                    break;
                case 2:
                    InitialiseDailyCalorieIntakeVsTargetGraph();
                    break;
                case 5:
                    InitialiseDailyMacroIntakeGraph();
                    break;
                default:
                    InitialiseWeightChangePerWeekGraph();
                    break;
            }
        }

        private async Task InitializeChart()
        {
            if (selectedGraph == 5)
            {
                if (barChart != null)
                {
                    await barChart.InitializeAsync(chartData, barChartOptions);
                }
            }
            else
            {
                if (lineChart != null)
                {
                    await lineChart.InitializeAsync(chartData, lineChartOptions);
                }
            }
        }

        private async Task UpdateChart()
        {
            if (selectedGraph == 5)
            {
                if (barChart != null)
                {
                    await barChart.UpdateAsync(chartData, barChartOptions);
                }
            }
            else
            {
                if (lineChart != null)
                {
                    await lineChart.UpdateAsync(chartData, lineChartOptions);
                }
            }
        }

        private void InitialiseWeightChangePerWeekGraph()
        {
            // Create initial labels and datasets for the chart
            chartData = new ChartData { Labels = GetDefaultDataLabels(6, "Week"), Datasets = GetDefaultDataSets(1, true, "Weight Change (kg)", false) };

            // Set default chart options (horizontal index axis, interaction mode, responsive)
            // and configure Y axis to allow negative values in the range -1 .. 1.
            lineChartOptions = new()
            {
                IndexAxis = "x",
                Interaction = new Interaction { Mode = InteractionMode.Index, Intersect = false },
                Responsive = true,


                // Scales configuration to allow negative values on Y axis.
                // Types used here are consistent with the chart types available in the project.
                Scales = new Scales
                {
                    Y = new()
                    {
                        BeginAtZero = false,
                        Min = -1,
                        Max = 1
                    }
                }
            };
        }

        private void InitialiseBodyweightOverTimeGraph()
        {
            // Create initial labels and datasets for the chart
            chartData = new ChartData { Labels = GetDefaultDataLabels(6, "Day"), Datasets = GetDefaultDataSets(1, false, "Body Weight (kg)", true, 0, 200) };

            // Set default chart options (horizontal index axis, interaction mode, responsive)
            // and configure Y axis to allow negative values in the range -1 .. 1.
            lineChartOptions = new()
            {
                IndexAxis = "x",
                Interaction = new Interaction { Mode = InteractionMode.Index, Intersect = false },
                Responsive = true,


                // Scales configuration to allow negative values on Y axis.
                // Types used here are consistent with the chart types available in the project.
                Scales = new Scales
                {
                    Y = new()
                    {
                        BeginAtZero = false,
                        Min = 0,
                        Max = 200
                    }
                }
            };
        }

        private void InitialiseDailyCalorieIntakeVsTargetGraph()
        {
            // Create initial labels and datasets for the chart
            chartData = new ChartData { Labels = GetDefaultDataLabels(6, "Day"), Datasets = GetDefaultDataSets(1, true, "Calories above/below Target", false) };

            // Set default chart options (horizontal index axis, interaction mode, responsive)
            // and configure Y axis to allow negative values in the range -1 .. 1.
            lineChartOptions = new()
            {
                IndexAxis = "x",
                Interaction = new Interaction { Mode = InteractionMode.Index, Intersect = false },
                Responsive = true,


                // Scales configuration to allow negative values on Y axis.
                // Types used here are consistent with the chart types available in the project.
                Scales = new Scales
                {
                    Y = new()
                    {
                        BeginAtZero = false,
                        Min = -1,
                        Max = 1
                    }
                }
            };
        }

        // Initialises a horizontal bar chart showing daily macro intake
        private void InitialiseDailyMacroIntakeGraph()
        {

            // Define labels and datasets for the bar chart
            var labels = new List<string> { "Carbs", "Protein", "Fat" };
            var datasets = new List<IChartDataset>();

            // Create and configure the dataset
            var dataset1 = new BarChartDataset()
            {
                Label = "Daily Macro Intake (g)",
                Data = new List<double?> { 250, 180, 70 },
                BackgroundColor = new List<string> 
                { 
                    ColorUtility.CategoricalTwelveColors[0],
                    ColorUtility.CategoricalTwelveColors[1],
                    ColorUtility.CategoricalTwelveColors[2]
                },
                BorderColor = new List<string> 
                { 
                    ColorUtility.CategoricalTwelveColors[0],
                    ColorUtility.CategoricalTwelveColors[1],
                    ColorUtility.CategoricalTwelveColors[2]
                },
                BorderWidth = new List<double> { 0 },
            };
            datasets.Add(dataset1);

            // Assign chart data
            chartData = new ChartData { Labels = labels, Datasets = datasets };

            // Configure bar chart options
            barChartOptions = new BarChartOptions();
            barChartOptions.Responsive = true;
            barChartOptions.Interaction = new Interaction { Mode = InteractionMode.Y };
            barChartOptions.IndexAxis = "y";

            barChartOptions.Scales.X!.Title = new ChartAxesTitle { Text = "Grams", Display = true };
            barChartOptions.Scales.Y!.Title = new ChartAxesTitle { Text = "Macro", Display = true };

            barChartOptions.Plugins.Legend.Display = true;
        }

        #region Data Preparation

        // Create a list of default datasets
        private List<IChartDataset> GetDefaultDataSets(int numberOfDatasets, bool baseline, string label, bool positive, int min = 0, int max = 0)
        {
            var datasets = new List<IChartDataset>();

            // Generate the requested number of random datasets
            for (var index = 0; index < numberOfDatasets; index++)
            {
                datasets.Add(GetRandomLineChartDataset(label, positive, min, max));
            }

            if (baseline)
            {
                // Adds 1 baseline line regardless of the number of datasets
                datasets.Add(GetBaselineLine());
            }

            return datasets;
        }

        // Build a single LineChartDataset with random data and styling
        private LineChartDataset GetRandomLineChartDataset(string label, bool positive, int min = 0, int max = 0)
        {
            // Select a color from a categorical palette based on datasetsCount
            var c = ColorUtility.CategoricalTwelveColors[datasetsCount].ToColor();

            // Increment the datasets counter (used for labeling and next color)
            datasetsCount += 1;

            // Return a configured dataset with label, random data and appearance settings
            return new LineChartDataset
            {
                Label = label,
                Data = positive ? GetRandomPositiveData(min, max) : GetRandomData(),
                BackgroundColor = c.ToRgbaString(),
                BorderColor = c.ToRgbString(),
                PointRadius = new List<double> { 5 },
                PointHoverRadius = new List<double> { 8 },
            };
        }

        //Generates a line that is horizontal, y = 0
        private LineChartDataset GetBaselineLine()
        {
            var c = ColorUtility.CategoricalTwelveColors[datasetsCount].ToColor();

            return new LineChartDataset
            {
                Label = $"Baseline",
                Data = GetBaseline(),
                BackgroundColor = c.ToRgbaString(),
                BorderColor = c.ToRgbString(),
                PointRadius = new List<double> { 5 },
                PointHoverRadius = new List<double> { 8 },
            };
        }

        // Generate a list of random numeric data points matching current label count
        // Now returns values in the range -1 .. 1.
        private List<double?> GetRandomData()
        {
            var data = new List<double?>();
            for (var index = 0; index < labelsCount; index++)
            {
                // random.NextDouble() --> [0.0, 1.0)
                // map to [-1.0, 1.0): (value * 2) - 1
                data.Add((random.NextDouble() * 2.0) - 1.0);
            }

            return data;
        }

        private List<double?> GetRandomPositiveData(int min, int max)
        {
            var data = new List<double?>();
            for (var index = 0; index < labelsCount; index++)
            {
                data.Add(random.Next(min, max + 1));
            }

            return data;
        }

        private List<double?> GetBaseline()
        {
            var data = new List<double?>();
            for (var index = 0; index < labelsCount; index++)
            {
                data.Add(0);
            }

            return data;
        }

        // Create a list of default labels using GetNextDataLabel
        private List<string> GetDefaultDataLabels(int numberOfLabels, string time)
        {
            var labels = new List<string>();
            for (var index = 0; index < numberOfLabels; index++)
            {
                labels.Add(GetNextDataLabel(time));
            }

            return labels;
        }

        // Produce the next sequential label (e.g., "Day 1", "Day 2") and increment label counter
        private string GetNextDataLabel(string time)
        {
            labelsCount += 1;
            return $"{time} {labelsCount}";
        }


        #endregion Data Preparation
    }
}

























